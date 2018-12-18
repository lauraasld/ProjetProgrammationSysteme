using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using System;
using System.Windows;

namespace View
{
    public class ViewFacade : IView
    {
        public IModel Model { get; set; }
        //public List<StaffElement> staffElements { get; set; }
        //public List<DiningTable> diningTables { get; set; }
        public MainWindow MainWindow { get; set; }
        //System.Timers.Timer timer;
        public ViewFacade(IModel model)
        {
            Model = model;
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
            /*timer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(RefreshLists);*/
        }

        public void Start()
        {

        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
        /*public void RefreshPersonPosition(PositionedElement person)
        {
            throw new System.Exception("Not implemented");
        }*/
        //Model.DiningRoom.Table
    }
}
