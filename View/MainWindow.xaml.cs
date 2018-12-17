using Model;
using Model.Kitchen.BLL;
using Model.Kitchen.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewFacade Model { get; set; }

        public List<IUserInputObserver> parametersObservers;
        public double SimulationSpeed = 1;
        public Settings settings;
        public List<StaffElement> StaffElements { get; set; }
        public List<DiningTable> DiningTables { get; set; }

        public List<ScenarioBusiness> scenarioList = new List<ScenarioBusiness>();
        public ScenarioService scenarioService = new ScenarioService();
        public int id;

        private Timer timer;
        public MainWindow(ViewFacade model)
        {
            Model = model;
            InitializeComponent();
            StaffElements = new List<StaffElement>() { new StaffElement("a", true, "a")};
            DiningTables = new List<DiningTable>();
            initializeLists();
            scenarioList = scenarioService.GetAll();
            ComboScenario.DisplayMemberPath = "Title";
            ComboScenario.SelectedValuePath = "Id";
            StaffGrid.ItemsSource = StaffElements;
            DiningTableGrid.ItemsSource = DiningTables;
            settings = new Settings();
            parametersObservers = new List<IUserInputObserver>();
            timer = new Timer(500);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(RefreshLists);
        }

        private void RefreshLists(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StaffElements.Clear();
                DiningTables.Clear();
                initializeLists();
                DiningTableGrid.Items.Refresh();
                StaffGrid.Items.Refresh();

            });
            //DiningTableGrid.Items.Refresh();
            /*DiningTableGrid.ItemsSource = null;
            DiningTableGrid.ItemsSource = DiningTables;
            DiningTableGrid.Items.Refresh();
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = StaffElements;*/
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboScenario.ItemsSource = scenarioList;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id = ComboScenario.SelectedIndex + 1;
            // parameters.NotifyObserversThatParametersConfigured();
        }

        public void initializeLists()
        {
            SimulationTime.Text = SimulationClock.GetInstance().SimulationDateTime.ToString();
            int i = 0;
            foreach (var Waiter in Model.Model.DiningRoom.Waiters)
            {
                i++;
                StaffElements.Add(new StaffElement("Serveur N°" + i, Waiter.IsBusy, Waiter.Action));
            }
            i = 0;
            foreach (var HeadWaiter in Model.Model.DiningRoom.HeadWaiters)
            {
                i++;
                StaffElements.Add(new StaffElement("Chef de Rang N°" + i, HeadWaiter.IsBusy, HeadWaiter.Action));
            }
            StaffElements.Add(new StaffElement("Maître d'hotel", Model.Model.DiningRoom.Butler.IsBusy, Model.Model.DiningRoom.Butler.Action));
            i = 0;
            foreach (var Dishwasher in Model.Model.Kitchen.Dishwashers)
            {
                i++;
                StaffElements.Add(new StaffElement("PlongeurN°" + i, Dishwasher.IsBusy, Dishwasher.Action));
            }
            i = 0;
            foreach (var Commis in Model.Model.Kitchen.Commis)
            {
                i++;
                StaffElements.Add(new StaffElement("Commis N°" + i, Commis.IsBusy, Commis.Action));
            }
            i = 0;
            foreach (var Cook in Model.Model.Kitchen.Cooks)
            {
                i++;
                StaffElements.Add(new StaffElement("Cuisinier N°" + i, Cook.IsBusy, Cook.Action));
            }
            StaffElements.Add(new StaffElement("Chef de cuisine", Model.Model.Kitchen.HeadChef.IsBusy, Model.Model.Kitchen.HeadChef.Action));
            foreach (var Table in Model.Model.DiningRoom.Tables)
            {
                string action = "";
                if (Table.SeatedCustomers.Count > 0)
                {
                    foreach (var item in Table.SeatedCustomers.Where(x => x.Action != null))
                    {
                        action += item.Action + "\n";
                    }
                }
                DiningTables.Add(new DiningTable("Table N°" + Table.TableNumber, Table.NumberOfPlaces, Table.SeatedCustomers.Count, action));
            }
        }

        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            /*if (settings == null)
            {
                settings = new Settings();
            }*/
            settings.ShowDialog();
        }

        public void NotifyObserversThatUserInputed(Order order, double simulationSpeed = -1, int scenarioId = -1)
        {
            foreach (IUserInputObserver observer in parametersObservers)
            {
                observer.UserInputReceived(order, simulationSpeed, scenarioId);
            }
        }

        public void SubscribeToUserInputObserve(IUserInputObserver observer)
        {
            parametersObservers.Add(observer);
        }
        public void UnsubscribeToUserInputObserve(IUserInputObserver observer)
        {
            parametersObservers.Remove(observer);
        }

        private void Button_Play(object sender, RoutedEventArgs e)
        {
            NotifyObserversThatUserInputed(Order.LaunchSimulation);
            //MessageBox.Show("text");
            PlayButton.IsEnabled = false;
            PauseButton.IsEnabled = true;
            timer.Start();

        }

        private void Button_FFWD(object sender, RoutedEventArgs e)
        {
            double speed;
            if (!double.TryParse(SimulationSpeedInput.Text, out speed))
            {
                MessageBox.Show("CE N'EST PAS UN DOUBLE");
            }
            NotifyObserversThatUserInputed(Order.ChangeSimulationSpeed, speed);
        }

        private bool simulationIsPaused = false;
        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            simulationIsPaused = simulationIsPaused ? false : true;
            NotifyObserversThatUserInputed(simulationIsPaused ? Order.PauseSimulation : Order.UnpauseSimulation);
            PauseButton.Content = simulationIsPaused ? "Reprendre" : "Pause";
            //DiningTableGrid.Items.Refresh();
        }

        private void StartScenarioButton_Click(object sender, RoutedEventArgs e)
        {
            NotifyObserversThatUserInputed(Order.StartNewScenario, id);
        }
    }

    public class DiningTable //: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public int PeopleSeated { get; set; }
        public string CustomerActions { get; set; }
        public DiningTable(string name, int seatCount, int peopleSeated, string customerActions)
        {
            Name = name;
            SeatCount = seatCount;
            PeopleSeated = peopleSeated;
            CustomerActions = customerActions;
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
    public class StaffElement
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public string State { get; set; }
        public StaffElement(string name, bool isBusy, string state)
        {
            Name = name;
            IsBusy = isBusy;
            State = state;
        }
    }
}
