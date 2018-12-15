using System.Threading;

namespace Model
{
    public class Person
    {
        public string Action { get; set; }
        public double TimeMultiplier { get; set; }

        public object lockObj { get; private set; } = new object();
        //public bool IsBusy { get; set; } = false;

        private int _threadSafeBoolBackValue = 0;

        public bool IsBusy
        {
            get { return (Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 1) == 1); }
            set
            {
                if (value) Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 0);
                else Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 0, 1);
            }
        }

        public Person()
        {
            SimulationClock.GetInstance().AddWaitToTimerRefresh(IncrementWaitedMinutes);
            TimeMultiplier = 1;
        }

        private int waitedMinutes = 0;
        protected void Wait(int simulationMinutesToWait)
        {
            waitedMinutes = 0;
            while (waitedMinutes <= simulationMinutesToWait * TimeMultiplier) { }
        }

        public void IncrementWaitedMinutes()
        {
            if (IsBusy)
                Interlocked.Increment(ref waitedMinutes);
        }
    }
}
