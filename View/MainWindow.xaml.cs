using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Model;
using System.Timers;
using System.Threading;
using System.Windows.Threading;


namespace View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<IUserInputObserver> parametersObservers;
        public double SimulationSpeed;
        public Settings settings;
        public MainWindow(List<StaffElement> staffElements, List<DiningTable> diningTables)
        {
            InitializeComponent();
            DiningTableGrid.ItemsSource = diningTables;
            StaffGrid.ItemsSource = staffElements;
            settings = new Settings();
            parametersObservers = new List<IUserInputObserver>();
        }
        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            /*if (settings == null)
            {
                settings = new Settings();
            }*/
            settings.ShowDialog();
        }

        public void NotifyObserversThatUserInputed(Order order, double simulationSpeed = -1)
        {
            foreach (IUserInputObserver observer in parametersObservers)
            {
                observer.UserInputReceived(order, simulationSpeed);
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
            MessageBox.Show("text");
            PlayButton.IsEnabled = false;
            PauseButton.IsEnabled = true;
        }

        private void Button_FFWD(object sender, RoutedEventArgs e)
        {
            NotifyObserversThatUserInputed(Order.ChangeSimulationSpeed, SimulationSpeed);
        }

        private bool simulationIsPaused = false;
        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            NotifyObserversThatUserInputed(simulationIsPaused ? Order.PauseSimulation : Order.UnpauseSimulation);
            simulationIsPaused = simulationIsPaused ? false : true;
            PauseButton.Content = simulationIsPaused ? "Reprendre" : "Pause";
        }
    }
}
