using View;
using Model;
using System;
using System.Collections.Generic;
using Model.DiningRoom;

namespace Controller
{
    public class ControllerFacade : IController
    {
        public IModel model { get;  private set; }
        public IView view { get; private set; }
        public int RealSecondsFor1MinuteInSimulation { get; set; }
        public DateTime SimulationTimeOfServiceStart { get; set; }
        private SimulationClock simulationClock;

        public ControllerFacade(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            simulationClock = SimulationClock.GetInstance();
            simulationClock.ChangeSimulationSpeed(RealSecondsFor1MinuteInSimulation);
        }

        public void StartSimulation()
        {
            simulationClock.StartSimulation(SimulationTimeOfServiceStart);
        }

        public void ScenarioLoop()
        {
            string actualScenarioAction = GetNextScenarioAction();
            List<string> actualScenarioActionParam = GetNextScenarioActionParam();

            switch (actualScenarioAction)
            {
                case "CreationReservation":
                    List<Customer> customers = new List<Customer>();
                    CustomersGroup c = new CustomersGroup(customers, true);
                    model.DiningRoom.Reception.BookedCustomersGroups.Add();
                    break;
                default:
                    break;
            }
        }

        private string GetNextScenarioAction()
        {
            return "";
        }

        private List<string> GetNextScenarioActionParam()
        {
            return new List<string>();
        }

    }
}
