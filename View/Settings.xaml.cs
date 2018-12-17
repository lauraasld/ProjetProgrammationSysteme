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
        public int id;

        public Settings()
        {
            parameters = new Parameters();
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
            id = ComboScenario.SelectedIndex + 1;
           // parameters.NotifyObserversThatParametersConfigured();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parameters.fFWDCoefficient = Convert.ToInt32(FFWDcoeficient.Text);
            parameters.nbOfCooks = Convert.ToInt32(CookNb.Text);
            parameters.nbOfCommis = Convert.ToInt32(CommisChefNb.Text);
            parameters.nbOfDishwasher = Convert.ToInt32(DishBoyNb.Text);
            parameters.nbOfHeadWaiter = Convert.ToInt32(RankChefNb.Text);
            parameters.nbOfWaiter = Convert.ToInt32(ServerNb.Text);
            parameters.cookCoef = Convert.ToInt32(CookCoef.Text);
            parameters.dishwasherCoef = Convert.ToInt32(DishBoyCoef.Text);
            parameters.headWaiterCoef = Convert.ToInt32(RankChefCoef.Text);
            parameters.headChefCoef = Convert.ToInt32(HeadChefCoef.Text);
            parameters.waiterCoef = Convert.ToInt32(ServerCoef.Text);
            parameters.commisChefCoef = Convert.ToInt32(CommisChefCoef.Text);
            parameters.commisSalleCoef = Convert.ToInt32(CommisRoomCoef.Text);
            parameters.butlerCoef = Convert.ToInt32(ButlerCoef.Text);

            parameters.scenarioId = id;
            //MessageBox.Show(parameters.nbOfCooks + CommisChefNb.Text + DishBoyNb.Text + RankChefNb.Text + ServerNb.Text + id);
            this.Hide();
            parameters.NotifyObserversThatParametersConfigured();
        }   
    }
}
