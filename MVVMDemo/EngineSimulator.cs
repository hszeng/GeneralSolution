using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WPF.MVVMDemo
{
    public class ModelSimulator
    {
        public string SimulateLongTimeWork(int seconds)
        {
            string rtn = null;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 300; i++)
            {
               
                rtn = rtn + rnd.Next(-100, 1000);
            }
            Thread.Sleep(new TimeSpan(0,0,seconds));          
            return rtn;
        }
        public string SimulateLongTimeWorkWithParameter(string para, int seconds)
        {
            string rtn = para + Environment.NewLine;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 300; i++)
            {
                rtn = rtn + rnd.Next(-100, 1000);
            }
            Thread.Sleep(new TimeSpan(0, 0, seconds));          
            return rtn;
        }
    }
}
