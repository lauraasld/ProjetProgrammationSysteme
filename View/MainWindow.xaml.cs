using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MainWindow(List<StaffElement> staffElements, List<DiningTable> diningTables)
        {
            InitializeComponent();
            DiningTableGrid.ItemsSource = diningTables;
            StaffGrid.ItemsSource = staffElements;
        }
        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
        }

        private void Button_Play(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("text");
        }

        private void Button_FFWD(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Pause(object sender, RoutedEventArgs e)
        {
        }
    }
}
