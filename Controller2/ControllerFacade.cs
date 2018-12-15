using Model;
using Model.DiningRoom;
using System;
using System.Collections.Generic;
using View;

namespace Controller
{
    public class ControllerFacade : IController
    {
        public IModel model { get; private set; }
        public IView view { get; private set; }
        public int RealSecondsFor1MinuteInSimulation { get; set; }
        public DateTime SimulationTimeOfServiceStart { get; set; }
        private SimulationClock simulationClock;

        public ControllerFacade(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            simulationClock = SimulationClock.GetInstance();
            simulationClock.ChangeSimulationSpeed(RealSecondsFor1MinuteInSimulation);
        }

        public void StartSimulation()
        {
            simulationClock.StartSimulation(SimulationTimeOfServiceStart);
        }

        public void ScenarioLoop()
        {
            string actualScenarioAction = GetNextScenarioAction();
            string[] actualScenarioActionParam = GetNextScenarioActionParam();
            CustomersGroup customers = null;
            switch (actualScenarioAction)
            {
                case "CreationReservation":
                    customers = new CustomersGroup(
                        CreateCustomersGroup(int.Parse(actualScenarioActionParam[1].Split('=')[1]),
                        int.Parse(actualScenarioActionParam[2].Split('=')[1]),
                        int.Parse(actualScenarioActionParam[3].Split('=')[1])), true);
                    DateTime reservationDate = new DateTime(SimulationTimeOfServiceStart.Year, SimulationTimeOfServiceStart.Month, SimulationTimeOfServiceStart.Day, int.Parse(actualScenarioActionParam[0].Split('h')[0]), 0, 0);
                    model.DiningRoom.Reception.BookedCustomersGroups.Add(customers, reservationDate);
                    break;
                case "ArriveeClientsReservation":
                    model.DiningRoom.Reception.BookedCustomersArrive(customers);
                    model.DiningRoom.Butler.AssignTable(customers);
                    break;
                case "ArriveeClientsNonReserve":
                    model.DiningRoom.Butler.AssignTable(customers);
                    break;
                case "AmenerClientsATable":
                    foreach (var headWaiter in model.DiningRoom.HeadWaiters)
                    {
                        if (!headWaiter.IsBusy)
                        {;
                            headWaiter.PlaceCustomersAtTable(customers, model.DiningRoom.Tables.Find(x => x.TableNumber);
                        }
                    }
                    break;
                case "PrendreLesCommandes":
                    foreach (var headWaiter in model.DiningRoom.HeadWaiters)
                    {
                        if (!headWaiter.IsBusy)
                        {
                            headWaiter.TakeOrders(/*recuperer numéro table*/);
                        }
                    }
                    //Séparer le dessert
                    break;
                case "PreparationDesCommandes":
                    break;
                case "AmenerPlatsEnSalle":
                    break;
                case "ClientsMangent":
                    break;
                case "DebarasserTable":
                    foreach (var waiter in model.DiningRoom.Waiters)
                    {
                        if (!waiter.IsBusy) waiter.ClearPlates(/*recuperer numéro table*/);
                    }
                    break;
                case "ClientPartent":
                    foreach (var waiter in model.DiningRoom.Waiters)
                    {
                        if (!waiter.IsBusy) waiter.ClearAndCleanTable(/*recuperer numéro table*/);
                    }
                    break;
                default:
                    break;
            }
        }

        private string GetNextScenarioAction()
        {

            return "";
        }

        private string[] GetNextScenarioActionParam()
        {
            int i = 1;
            return new string[i];
        }

        private List<Customer> CreateCustomersGroup(int nbOfCustomersToCreate, int nbOfSlowCustomers, int nbOfFastCustomers)
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < nbOfSlowCustomers; i++)
            {
                customers.Add(new Customer(0.5));
                nbOfCustomersToCreate--;
            }
            for (int i = 0; i < nbOfFastCustomers; i++)
            {
                customers.Add(new Customer(1.5));
                nbOfCustomersToCreate--;
            }
            for (int i = 0; i < nbOfCustomersToCreate; i++)
            {
                customers.Add(new Customer(1));
            }
            return customers;
        }

    }
}
