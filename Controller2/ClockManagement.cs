using System;
using System.Timers;

namespace Controller
{
    public class ClockManagement
    {
        private Simulation simulation;

        public Timer timer { get; set; }
        public DateTime SimulationDateTime { get; set; }

        public ClockManagement(Simulation simulation)
        {
            timer = new Timer();
            timer.Elapsed += RefreshSimulationDateTime;
            this.simulation = simulation;
        }


        public void PauseSimulation()
        {
            timer.Stop();
        }

        public void UnpauseSimulation()
        {
            timer.Start();
        }

        public void ChangeSimulationSpeed(int realSecondsFor1MinuteInSimulation)
        {
            timer.Interval = realSecondsFor1MinuteInSimulation * 1000;
        }

        private void RefreshSimulationDateTime(object source, ElapsedEventArgs e)
        {
            SimulationDateTime.AddMinutes(10);
        }
    }
}
