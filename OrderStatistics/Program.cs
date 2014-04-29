using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.OrderStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] data = new int[] { 23, 12, 45, 15, 1, 79, 8 };
            int[] data = new int[] { 23, 12, 45, 15, 1, 79, 8, -1 };
            var minmaxfinder = new MinMaxFinder<int>();
            int min, max;
            minmaxfinder.FindMinMax(data, 0, data.Length - 1, out min, out max);
            Console.WriteLine("min:{0}  max:{1}", min, max);
            //------------------------------------------------------------------
            FindSpecialOrderElement<int> ESOE = new FindSpecialOrderElement<int>();
            int[] data1 = new int[10] { 1, 2, 3, 20, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine();
            data1.ToList<int>().ForEach(i => Console.Write("{0},", i));
            int e = ESOE.FindElementWithOrder(data1, 0, data1.Length - 1, 4);
            Console.WriteLine("Find the 4th small element:{0}", e);

            int[] data2 = new int[10] { 6, 90, 8, 9, 10, 1, 2, 3, 4, 5 };
            Console.WriteLine();
            data2.ToList<int>().ForEach(i => Console.Write("{0},", i));
            int f = ESOE.FindElementWithOrder(data2, 0, data1.Length - 1, 7);
            Console.WriteLine("Find the 7th small element:{0}", f);
            Console.ReadKey();
        }
    }
}
