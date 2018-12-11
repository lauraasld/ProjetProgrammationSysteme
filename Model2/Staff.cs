using System.Threading;

namespace Model
{
    public class Staff
    {
        public string Action { get; set; }

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
    }
}
