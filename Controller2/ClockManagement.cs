using System;
using System.Timers;

namespace Controller
{
    public delegate void WaitMethod();

    public class ClockManagement
    {
        private WaitMethod waitMethods;

        public Timer timer { get; private set; }
        public DateTime SimulationDateTime { get; set; }

        private ClockManagement()
        {
            timer = new Timer();
            timer.Elapsed += RefreshSimulationTime;
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

        private void RefreshSimulationTime(object source, ElapsedEventArgs e)
        {
            SimulationDateTime.AddMinutes(1);
            waitMethods();
        }

        public void AddWaitToTimerRefresh(WaitMethod myDelegate)
        {
            waitMethods += myDelegate;
        }
    }

}
