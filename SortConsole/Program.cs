using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Introduction2Algorithms.Sort;

namespace Introduction2Algorithms.SortConsole
{
    class Program
    {
        public static readonly int SIZE = 100000;
        public static readonly int MAXVAULE = 10000;
        public static readonly int STARTINDEX = 50;
        public static readonly int ENDINDEX = SIZE - 55;

        static void Main(string[] args)
        {
            List<ISort<int>> CompareBasedSort = new List<ISort<int>>()
            {
                new QuickSort<int>(),
                new QuickSortParallel<int>(),
                new SelectionSort<int>(),
                new InsertionSort<int>(),
                new BubbleSort<int>(),              
            };
            int[] data = initIntArray(SIZE, MAXVAULE);
            Console.WriteLine("Interger array size:{0}", SIZE);
            Console.WriteLine("Value range:{0}-{1}", 0, MAXVAULE);
            Console.WriteLine("Sorting index range:{0}-{1}", STARTINDEX, ENDINDEX);

            //Create the standard result for verifying the result
            int[] standardResult = new int[data.Length];
            data.CopyTo(standardResult, 0);
            (new CountingSort()).Sort(standardResult, STARTINDEX, ENDINDEX, 0, MAXVAULE);
            //

            Stopwatch sw = new Stopwatch();
            CompareBasedSort.ForEach(sf =>
            {
                int[] d = new int[data.Length];
                data.CopyTo(d, 0);
                Console.WriteLine();
                Console.WriteLine("{0}", sf.GetType());
                sw.Reset();
                sw.Start();
                sf.Sort(d, STARTINDEX, ENDINDEX);
                sw.Stop();
                Console.WriteLine("Time:{0}s", sw.Elapsed.TotalSeconds);

                // printArray(d, 0, d.Length - 1);
                Console.Write("Verify result:");
                bool isSortOK = IsResultCorrect(standardResult, d, STARTINDEX, ENDINDEX);
                if (isSortOK)
                { Console.ForegroundColor = ConsoleColor.Green; }
                else
                { Console.ForegroundColor = ConsoleColor.Red; }
                Console.Write(isSortOK == true ? "Pass" : "Fail");
                Console.Write(Environment.NewLine);
                Console.ResetColor();
                GC.Collect();
            });
            Console.WriteLine(Environment.NewLine + "All complete!");
            Console.ReadKey();
        }

        private static int[] initIntArray(int arraySize, int maxValue)
        {
            int[] data = new int[arraySize];
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arraySize; i++)
            {
                data[i] = rnd.Next(0, maxValue);
            }
            return data;
        }
        private static void printArray(int[] array, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(array[i]);
                if (i != end)
                    Console.Write(",");
            }
        }
        private static bool IsResultCorrect(int[] StandardBase, int[] arrayToCompare, int start, int end)
        {
            bool r = true;
            for (int i = start; i <= end; i++)
            {
                if (StandardBase[i] != arrayToCompare[i])
                {
                    r = false;
                    break;
                }
            }
            return r;
        }
    }
}
