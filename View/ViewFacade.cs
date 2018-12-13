using Model;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace View
{
    public class ViewFacade : IView
    {
        IModel model;
        public IEventPerformer eventPerformer { get; private set; }
        public List<StaffElement> staffElements { get; set; }
        public List<DiningTable> diningTables { get; set; }
        public ViewFacade(IModel model, IEventPerformer eventPerformer)
        {
            this.model = model;
            this.eventPerformer = eventPerformer;
            staffElements = new List<StaffElement>();
            diningTables = new List<DiningTable>();
            initializeLists();
            MainWindow mainWindow = new MainWindow(staffElements);
            mainWindow.ShowDialog();
        }

        private void initializeLists()
        {
            int i = 0;
            foreach (var Waiter in model.DiningRoom.Waiters)
            {
                i++;
                staffElements.Add(new StaffElement("Serveur N°"+i, Waiter.IsBusy,Waiter.Action));
            }
            i = 0;
            foreach (var HeadWaiter in model.DiningRoom.HeadWaiters)
            {
                i++;
                staffElements.Add(new StaffElement("Chef de Rang N°" + i, HeadWaiter.IsBusy, HeadWaiter.Action));
            }
            staffElements.Add(new StaffElement("Maître d'hotel", model.DiningRoom.Butler.IsBusy, model.DiningRoom.Butler.Action));
            i = 0;
            foreach (var Dishwasher in model.Kitchen.Dishwashers)
            {
                i++;
                staffElements.Add(new StaffElement("PlongeurN°" + i, Dishwasher.IsBusy, Dishwasher.Action));
            }
            i = 0;
            foreach (var Commis in model.Kitchen.Commis)
            {
                i++;
                staffElements.Add(new StaffElement("Commis N°" + i, Commis.IsBusy, Commis.Action));
            }
            i = 0;
            foreach (var Cook in model.Kitchen.Cooks)
            {
                i++;
                staffElements.Add(new StaffElement("Cuisinier N°" + i, Cook.IsBusy, Cook.Action));
            }
            staffElements.Add(new StaffElement("Chef de cuisine", model.Kitchen.HeadChef.IsBusy, model.Kitchen.HeadChef.Action));
            foreach (var Table in model.DiningRoom.Tables)
            {
                //diningTables.Add(new DiningTable(Table))
            }

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
        public int SeatCount { get; set; }
        public int PeopleSeated { get; set; }

    }
    public struct StaffElement {
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
