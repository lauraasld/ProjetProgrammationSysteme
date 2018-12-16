using Model;
using Model.DiningRoom;
using Model.Kitchen.BLL;
using Model.Kitchen.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using View;

namespace Controller
{
    public class ControllerFacade : IController, IPlatesToServeObserver
    {
        public IModel model { get; private set; }
        public IView view { get; private set; }
        public double RealSecondsFor1MinuteInSimulation { get; set; } = 0.1;
        public DateTime SimulationTimeOfServiceStart { get; set; }
        private SimulationClock simulationClock;
        public ActionsListService actionsListService = new ActionsListService();
        private List<ActionsListBusiness> actionsList = null;
        private string[] nextAction;

        public ControllerFacade(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            simulationClock = SimulationClock.GetInstance();
            simulationClock.ChangeSimulationSpeed(RealSecondsFor1MinuteInSimulation);
            model.DiningRoom.Countertop.SubscribeToNewPlateIsReady(this);
            actionsList = actionsListService.GetByScenario(1/*numéro de scénar renseigné*/);
            SimulationTimeOfServiceStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            StartSimulation();
            ScenarioLoop();
        }

        public void StartSimulation()
        {
            simulationClock.StartSimulation(SimulationTimeOfServiceStart);
            lock (model.Kitchen.HeadChef.lockObj)
            {
                model.Kitchen.HeadChef.PrepareMenus();
            }
        }

        private Dictionary<int, AutoResetEvent> ThreadSyncByTableNumber = new Dictionary<int, AutoResetEvent>();
        public void ScenarioLoop()
        {

            CustomersGroup customers = null;
            int tableNumber = 0;
            string actualScenarioAction = null;
            string[] actualScenarioActionParam = null;
            do
            {
                actualScenarioAction = GetNextScenarioAction();
                actualScenarioActionParam = GetNextScenarioActionParam();
                switch (actualScenarioAction)
                {
                    case "CreationReservation":
                        customers = new CustomersGroup(
                            CreateCustomersGroup(int.Parse(actualScenarioActionParam[1].Split('=')[1]),
                            int.Parse(actualScenarioActionParam[2].Split('=')[1]),
                            int.Parse(actualScenarioActionParam[3].Split('=')[1])), true);
                        DateTime reservationDate = new DateTime(SimulationTimeOfServiceStart.Year, SimulationTimeOfServiceStart.Month, SimulationTimeOfServiceStart.Day, 18/*int.Parse(actualScenarioActionParam[0].Split('h')[0])*/, 0, 0);
                        lock (model.DiningRoom.Butler.lockObj)
                        {
                            tableNumber = model.DiningRoom.Butler.CreateBooking(customers, reservationDate);
                        }
                        break;
                    case "ArriveeClientsReservation":
                        model.DiningRoom.Reception.BookedCustomersArrive(customers);
                        lock (model.DiningRoom.Butler.lockObj)
                        {
                            //tableNumber = model.DiningRoom.Butler.FindTable(customers);
                            ThreadSyncByTableNumber.Add(tableNumber, new AutoResetEvent(false));
                        }
                        break;
                    case "ArriveeClientsNonReserve":
                        customers = new CustomersGroup(
                            CreateCustomersGroup(int.Parse(actualScenarioActionParam[1].Split('=')[1]),
                            int.Parse(actualScenarioActionParam[2].Split('=')[1]),
                            int.Parse(actualScenarioActionParam[3].Split('=')[1])), true);
                        model.DiningRoom.Reception.BookedCustomersArrive(customers);
                        lock (model.DiningRoom.Butler.lockObj)
                        {
                            tableNumber = model.DiningRoom.Butler.FindTable(customers);
                            ThreadSyncByTableNumber.Add(tableNumber, new AutoResetEvent(false));
                        }
                        break;
                    case "AmenerClientsATable":
                        HeadWaiter headWaiter = null;
                        do
                        {
                            headWaiter = model.DiningRoom.HeadWaiters.FirstOrDefault(x => x.IsBusy == false);
                        } while (headWaiter == null);
                        lock (headWaiter.lockObj)
                        {
                            headWaiter.PlaceCustomersAtTable(customers, tableNumber);
                        }
                        break;
                    case "PrendreLesCommandes": /*Si parametre, alors on passe a false les values qui n'y sont pas*/
                        //model.DiningRoom.HeadWaiters.Find(x => x.IsBusy == false).TakeOrders(tableNumber);
                        headWaiter = null;
                        do
                        {
                            headWaiter = model.DiningRoom.HeadWaiters.FirstOrDefault(x => x.IsBusy == false);
                        } while (headWaiter == null);
                        lock (headWaiter.lockObj)
                        {
                            headWaiter.TakeOrders(tableNumber);
                        }
                        break;
                    case "PreparationDesCommandes":
                        lock (model.Kitchen.HeadChef.lockObj)
                        {
                            model.Kitchen.HeadChef.StartCoursesOrderPreparation(model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber));
                        }
                        break;
                    case "AmenerPlatsEnSalle":
                        ThreadSyncByTableNumber.First(x => x.Key == tableNumber).Value.WaitOne();
                        break;
                    case "ClientsMangent":
                        int i = 0;
                        Thread[] eatingCustomersThreads = new Thread[model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber).ServedFood.Count];
                        foreach (Customer customer in model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber).SeatedCustomers)
                        {
                            if (i >= model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber).ServedFood.Count)
                                break;
                            int j = i;
                            eatingCustomersThreads[i] = new Thread(delegate ()
                            {
                                lock (customer.lockObj)
                                {
                                    customer.EatFood(model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber).ServedFood[j]);
                                }
                            });
                            eatingCustomersThreads[i].Start();
                            i++;
                        }
                        for (int y = 0; y < eatingCustomersThreads.Length; y++)
                        {
                            eatingCustomersThreads[y].Join();
                        }
                        break;
                    case "DebarasserTable":
                        Waiter waiter = null;
                        //while (model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber).ServedFood.TrueForAll(x => x.IsFinished)) { }
                        do
                        {
                            waiter = model.DiningRoom.Waiters.FirstOrDefault(x => x.IsBusy == false);
                        } while (waiter == null);
                        lock (waiter.lockObj)
                        {
                            model.DiningRoom.Waiters.Find(x => x.IsBusy == false).ClearPlates(tableNumber);//TODO
                        }
                        break;
                    case "ClientsPartent":
                        waiter = null;
                        do
                        {
                            waiter = model.DiningRoom.Waiters.FirstOrDefault(x => x.IsBusy == false);
                        } while (waiter == null);
                        lock (waiter.lockObj)
                        {
                            model.DiningRoom.Tables.Find(x => x.TableNumber == tableNumber).SeatedCustomers.Clear();
                            model.DiningRoom.Waiters.Find(x => x.IsBusy == false).ClearAndCleanTable(tableNumber);
                        }
                        break;
                    default:
                        break;
                }
            } while (actualScenarioAction != "ClientsPartent");
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
            if (nextAction.Count() > 1)
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
                customers.Add(new Customer(false, true, true, 0.5));
                nbOfCustomersToCreate--;
            }
            for (int i = 0; i < nbOfFastCustomers; i++)
            {
                customers.Add(new Customer(true, true, true, 1.5));
                nbOfCustomersToCreate--;
            }
            for (int i = 0; i < nbOfCustomersToCreate; i++)
            {
                customers.Add(new Customer(true, true, false, 1));
            }
            return customers;
        }

        public void NewPlateIsReady()
        {
            Waiter waiter = null;
            do
            {
                waiter = model.DiningRoom.Waiters.FirstOrDefault(x => x.IsBusy == false);
            } while (waiter == null);
            lock (waiter.lockObj)
            {
                int numberOfTableReadyToBeServed = waiter.FindTableReadyToBeServed();
                if (numberOfTableReadyToBeServed != -1)
                {
                    waiter.ServeFood(numberOfTableReadyToBeServed);
                    ThreadSyncByTableNumber.First(x => x.Key == numberOfTableReadyToBeServed).Value.Set();
                }
            }
        }
    }
}
