using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimeOutTask
{
    public class Model
    {
        public string GetDataWithLongTime()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            return "Data from DataWithLongTime";
        }
        public string GetDataWithShortTime()
        {
            return "Data from DataWithShortTime";
        }
    }
}
