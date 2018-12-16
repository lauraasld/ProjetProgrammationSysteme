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
using System.Windows.Shapes;
using Model.Kitchen.BLL;
using Model.Kitchen.DAL;

namespace View
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public List<ScenarioBusiness> scenarioList = new List<ScenarioBusiness>();
        public ScenarioService scenarioService = new ScenarioService();
        public Parameters parameters;

        public Settings()
        {
            InitializeComponent();
            scenarioList = scenarioService.GetAll();
            ComboScenario.DisplayMemberPath = "Title";
            ComboScenario.SelectedValuePath = "Id";

        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("stuff");
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboScenario.ItemsSource = scenarioList;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ComboScenario.SelectedIndex + 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parameters.nbOfCooks = int.Parse(CookNb.Text);
            parameters.nbOfCommis = int.Parse(CommisChefNb.Text);
            parameters.nbOfDishwasher = int.Parse(DishBoyNb.Text);
            parameters.nbOfHeadWaiter = int.Parse(RankChefNb.Text);
            parameters.nbOfWaiter = int.Parse(ServerNb.Text);

        }
    }
}
