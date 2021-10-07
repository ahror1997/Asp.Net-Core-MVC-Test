using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Components
{
    public class TimerViewComponent
    {
        public string Invoke()
        {
            return $"Time: { DateTime.Now.ToString("hh:mm:ss")} ";
        }
    }
}
