using Model;
using Model.DiningRoom;
using System;
using System.Collections.Generic;
using View;
using Model.Kitchen.BLL;
using Model.Kitchen.DAL;

namespace Controller
{
    public class ControllerFacade : IController
    {
        public IModel model { get; private set; }
        public IView view { get; private set; }
        public int RealSecondsFor1MinuteInSimulation { get; set; }
        public DateTime SimulationTimeOfServiceStart { get; set; }
        private SimulationClock simulationClock;
        public ActionsListService actionsListService = new ActionsListService();
        List<ActionsListBusiness> actionsList = null;
        string[] nextAction;

        public ControllerFacade(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            simulationClock = SimulationClock.GetInstance();
            simulationClock.ChangeSimulationSpeed(RealSecondsFor1MinuteInSimulation);
            actionsList = actionsListService.GetByScenario(1/*numéro de scénar renseigné*/);
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
            int table = 0;
            if(actualScenarioAction == "ArriveeClientsNonReserve" || actualScenarioAction == "ArriveeClientsReservation")
            {
                table = model.DiningRoom.Tables.FindLast(x => x.IsAvailable == false).TableNumber;
            }
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
                    model.DiningRoom.HeadWaiters.Find(x => x.IsBusy == false).PlaceCustomersAtTable(customers, table);                                    
                    break;
                case "PrendreLesCommandes": /*Si parametre, alors on passe a false les values qui n'y sont pas*/
                    model.DiningRoom.HeadWaiters.Find(x => x.IsBusy == false).TakeOrders(table);
                    break;
                case "PreparationDesCommandes":
                    model.Kitchen.HeadChef.StartCoursesOrderPreparation(/*tableOrder*/);
                    break;
                case "AmenerPlatsEnSalle":
                    model.Kitchen.Commis.Find(x => x.IsBusy == false).BringPlateToCountertop(/*plat*/);
                    model.DiningRoom.Waiters.Find(x => x.IsBusy == false).NewPlateIsReady();
                    break;
                case "ClientsMangent":
                    break;
                case "DebarasserTable":
                    model.DiningRoom.Waiters.Find(x => x.IsBusy == false).ClearPlates(table);
                    break;
                case "ClientPartent":
                    model.DiningRoom.Waiters.Find(x => x.IsBusy == false).ClearAndCleanTable(table);
                    break;
                default:
                    break;
            }
        }

        private string GetNextScenarioAction()
        {
            nextAction = actionsList[0].Action.Name.Split(':');
            actionsList.RemoveAt(0);
            return nextAction[0];
        }

        private string[] GetNextScenarioActionParam()
        {
            string[] paramAction = null;
            if (nextAction[1] != null)
            {
                paramAction = nextAction[1].Split(',');
            }
            return paramAction;
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
