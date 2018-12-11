using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Staff
    {
        protected object lockObj = new object();
        public bool IsBusy { get; set; } = false;

    }
}
