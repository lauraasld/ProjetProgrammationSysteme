﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IParametersObserver
    {
        void ParametersConfigured(Parameters parameters);
    }
}
