using System;
using System.Timers;

namespace Model
{
    public delegate void WaitMethod();

    public class SimulationClock
    {
        private static SimulationClock instance;
        private WaitMethod waitMethods;

        public Timer timer { get; private set; }
        public DateTime SimulationDateTime { get; set; }

        private SimulationClock()
        {
            timer = new Timer();
            timer.Stop();
            timer.Elapsed += RefreshSimulationTime;
        }

        public static SimulationClock GetInstance()
        {
            if (instance == null)
            {
                instance = new SimulationClock();
            }
            return instance;
        }

        public void StartSimulation(DateTime simulationStartingDateTime)
        {
            SimulationDateTime = simulationStartingDateTime;
            UnpauseSimulation();
        }

        public void PauseSimulation()
        {
            timer.Stop();
        }

        public void UnpauseSimulation()
        {
            timer.Start();
        }

        public void ChangeSimulationSpeed(double realSecondsFor1MinuteInSimulation)
        {
            timer.Interval = realSecondsFor1MinuteInSimulation * 1000;
        }

        private void RefreshSimulationTime(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Tick");
            SimulationDateTime.AddMinutes(1);
            waitMethods();
        }

        public void AddWaitToTimerRefresh(WaitMethod myDelegate)
        {
            waitMethods += myDelegate;
        }
    }

}
