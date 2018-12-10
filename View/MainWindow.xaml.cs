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

namespace View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Staff
        {
            public string Function { get; set; }
            public bool IsBusy { get; set; }
        }
        public class DiningTable
        {
            public int SeatCount { get; set; }
            public int PeopleSeated { get; set; }
        }
        private List<Staff> ListStaff()
        {
            List<Staff> stafflist = new List<Staff>();
            stafflist.Add(new Staff() { Function = "cuisinier", IsBusy = true });
            stafflist.Add(new Staff() { Function = "serveur", IsBusy = false });
            stafflist.Add(new Staff() { Function = "chef de table", IsBusy = false });
            stafflist.Add(new Staff() { Function = "commis de cuisine", IsBusy = true });
            return stafflist;
        }
        private List<DiningTable> ListDiningTable()
        {
            List<DiningTable> diningtablelist = new List<DiningTable>();
            diningtablelist.Add(new DiningTable() { SeatCount = 8, PeopleSeated = 7 });
            diningtablelist.Add(new DiningTable() { SeatCount = 8, PeopleSeated = 0 });
            diningtablelist.Add(new DiningTable() { SeatCount = 4, PeopleSeated = 2 });
            diningtablelist.Add(new DiningTable() { SeatCount = 4, PeopleSeated = 0 });
            diningtablelist.Add(new DiningTable() { SeatCount = 4, PeopleSeated = 3 });
            diningtablelist.Add(new DiningTable() { SeatCount = 2, PeopleSeated = 2 });
            return diningtablelist;
        }

        public MainWindow()
        {
            InitializeComponent();
            StaffGrid.ItemsSource = ListStaff();
            DiningTableGrid.ItemsSource = ListDiningTable();
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
