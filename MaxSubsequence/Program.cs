using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maxsubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] dArray = new double[] { 2, -3, 1.5, -1, 3, -2, -3, 3 };
            dArray.ToList<double>().ForEach(d => Console.Write("{0} ", d));
            int startIndex;
            double max = MaxSubsequenceUtil.FindMaxSubsequence(dArray, out startIndex);
            if (max == 0)
            {
                Console.WriteLine("No max subsequence exist!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("The max total is:{0}", max);
                Console.WriteLine("The max subsequence is:");
                double t = 0;
                for (int i = startIndex; i < dArray.Length; i++)
                {
                    t += dArray[i];
                    if (t == max)
                    {
                        Console.Write("{0} ", dArray[i]);
                        break;
                    }
                    Console.Write("{0} ", dArray[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
