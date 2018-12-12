namespace Controller
{
    public class Simulation
    {
        private ControllerFacade controller;
        private ClockManagement clockManagement;

        public Simulation(ControllerFacade controllerFacade)
        {
            controller = controllerFacade;
            clockManagement = new ClockManagement(this);
        }

        public void InitializeSimulation()
        {
            throw new System.Exception("Not implemented");
        }
        public void StartSimulation()
        {
            throw new System.Exception("Not implemented");
        }
        private void ManageKitchenPersonnel()
        {
            throw new System.Exception("Not implemented");
        }
        private void ManageDiningRoomPersonnel()
        {
            throw new System.Exception("Not implemented");
        }


    }
}
