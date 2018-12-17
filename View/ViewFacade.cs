using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using System;

namespace View
{
    public class ViewFacade : IView
    {
        public IModel Model { get; set; }
        public IEventPerformer eventPerformer { get; private set; }
        //public List<StaffElement> staffElements { get; set; }
        //public List<DiningTable> diningTables { get; set; }
        public MainWindow MainWindow { get; set; }
        System.Timers.Timer timer;
        public ViewFacade(IModel model, IEventPerformer eventPerformer)
        {
            Model = model;
            this.eventPerformer = eventPerformer;
            //staffElements = new List<StaffElement>();
            //diningTables = new List<DiningTable>();
            //initializeLists();
            Thread thread = new Thread(() =>
            {
                MainWindow = new MainWindow(this/*staffElements, diningTables*/);
                MainWindow.ShowDialog();
                Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            timer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(RefreshLists);
        }

        public void Start()
        {
            //timer.Start();
        }

        /*public void initializeLists()
        {
            int i = 0;
            foreach (var Waiter in Model.DiningRoom.Waiters)
            {
                i++;
                MainWindow.StaffElements.Add(new StaffElement("Serveur N°" + i, Waiter.IsBusy, Waiter.Action));
            }
            i = 0;
            foreach (var HeadWaiter in Model.DiningRoom.HeadWaiters)
            {
                i++;
                MainWindow.StaffElements.Add(new StaffElement("Chef de Rang N°" + i, HeadWaiter.IsBusy, HeadWaiter.Action));
            }
            MainWindow.StaffElements.Add(new StaffElement("Maître d'hotel", Model.DiningRoom.Butler.IsBusy, Model.DiningRoom.Butler.Action));
            i = 0;
            foreach (var Dishwasher in Model.Kitchen.Dishwashers)
            {
                i++;
                MainWindow.StaffElements.Add(new StaffElement("PlongeurN°" + i, Dishwasher.IsBusy, Dishwasher.Action));
            }
            i = 0;
            foreach (var Commis in Model.Kitchen.Commis)
            {
                i++;
                MainWindow.StaffElements.Add(new StaffElement("Commis N°" + i, Commis.IsBusy, Commis.Action));
            }
            i = 0;
            foreach (var Cook in Model.Kitchen.Cooks)
            {
                i++;
                MainWindow.StaffElements.Add(new StaffElement("Cuisinier N°" + i, Cook.IsBusy, Cook.Action));
            }
            MainWindow.StaffElements.Add(new StaffElement("Chef de cuisine", Model.Kitchen.HeadChef.IsBusy, Model.Kitchen.HeadChef.Action));
            foreach (var Table in Model.DiningRoom.Tables)
            {
                MainWindow.DiningTables.Add(new DiningTable("Table N°" + Table.TableNumber, Table.NumberOfPlaces, Table.NumberOfSeatedCustomers));
            }
        }*/
        public void RefreshLists(object sender, ElapsedEventArgs e)
        {
            /*MainWindow.DiningTables = null;
            MainWindow.StaffElements = null;*/
            //initializeLists();
            /*MainWindow.DiningTableGrid.ItemsSource = null;
            MainWindow.DiningTableGrid.ItemsSource = diningTables;
            MainWindow.StaffGrid.ItemsSource = null;
            MainWindow.StaffGrid.ItemsSource = staffElements;*/
        }
        public void DisplayMessage(string message)
        {
            throw new System.Exception("Not implemented");
        }
        /*public void RefreshPersonPosition(PositionedElement person)
        {
            throw new System.Exception("Not implemented");
        }*/
        //Model.DiningRoom.Table
    }
}
