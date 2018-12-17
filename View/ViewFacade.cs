using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace View
{
    public class ViewFacade : IView
    {
        public IModel Model { get; set; }
        public IEventPerformer eventPerformer { get; private set; }
        public List<StaffElement> staffElements { get; set; }
        public List<DiningTable> diningTables { get; set; }
        public MainWindow MainWindow { get; set; }
        public ViewFacade(IModel model, IEventPerformer eventPerformer)
        {
            Model = model;
            this.eventPerformer = eventPerformer;
            staffElements = new List<StaffElement>();
            diningTables = new List<DiningTable>();
            initializeLists();
            Thread thread = new Thread(() =>
            {
                MainWindow = new MainWindow(staffElements, diningTables);
                MainWindow.ShowDialog();
                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(RefreshLists);
            timer.Start();
        }

        public void initializeLists()
        {
            int i = 0;
            foreach (var Waiter in Model.DiningRoom.Waiters)
            {
                i++;
                staffElements.Add(new StaffElement("Serveur N°" + i, Waiter.IsBusy, Waiter.Action));
            }
            i = 0;
            foreach (var HeadWaiter in Model.DiningRoom.HeadWaiters)
            {
                i++;
                staffElements.Add(new StaffElement("Chef de Rang N°" + i, HeadWaiter.IsBusy, HeadWaiter.Action));
            }
            staffElements.Add(new StaffElement("Maître d'hotel", Model.DiningRoom.Butler.IsBusy, Model.DiningRoom.Butler.Action));
            i = 0;
            foreach (var Dishwasher in Model.Kitchen.Dishwashers)
            {
                i++;
                staffElements.Add(new StaffElement("PlongeurN°" + i, Dishwasher.IsBusy, Dishwasher.Action));
            }
            i = 0;
            foreach (var Commis in Model.Kitchen.Commis)
            {
                i++;
                staffElements.Add(new StaffElement("Commis N°" + i, Commis.IsBusy, Commis.Action));
            }
            i = 0;
            foreach (var Cook in Model.Kitchen.Cooks)
            {
                i++;
                staffElements.Add(new StaffElement("Cuisinier N°" + i, Cook.IsBusy, Cook.Action));
            }
            staffElements.Add(new StaffElement("Chef de cuisine", Model.Kitchen.HeadChef.IsBusy, Model.Kitchen.HeadChef.Action));
            foreach (var Table in Model.DiningRoom.Tables)
            {
                diningTables.Add(new DiningTable("Table N°" + Table.TableNumber, Table.NumberOfPlaces, Table.NumberOfSeatedCustomers));
            }

        }
        public void RefreshLists(object sender, ElapsedEventArgs e)
        {
            staffElements.Clear();
            diningTables.Clear();
            initializeLists();  
            
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
    public struct DiningTable
    {
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public int PeopleSeated { get; set; }
        public DiningTable(string name, int seatCount, int peopleSeated) : this()
        {
            Name = name;
            SeatCount = seatCount;
            PeopleSeated = peopleSeated;
        }

    }
    public struct StaffElement
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public string State { get; set; }
        public StaffElement(string name, bool isBusy, string state) : this()
        {
            Name = name;
            IsBusy = isBusy;
            State = state;
        }
    }

}
