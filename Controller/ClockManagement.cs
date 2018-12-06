using System;
using System.Timers;

namespace Controller
{
    public class ClockManagement
    {
        private Timer timer;
        private Simulation simulation;
        public DateTime SimulationDateTime { get; set; }

        public void PauseSimulation()
        {
            throw new System.Exception("Not implemented");
        }
        public void UnpauseSimulation()
        {
            throw new System.Exception("Not implemented");
        }
        public void ChangeSimulationSpeed(int timeMultiplier)
        {
            throw new System.Exception("Not implemented");
        }
        private void RefreshSimulationDateTime(int simulationTimeRefreshInterval)
        {
            throw new System.Exception("Not implemented");
        }
    }
}
