using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Introduction2Algorithms.Outline
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Test Case 1 ,书上的例子
            Building<int>[] blds = new Building<int>[]
                {
                new Building<int>(1,11,5),
                new Building<int>(2,6,7),
                new Building<int>(3,13,9),
                new Building<int>(12,7,16),
                new Building<int>(14,3,25),
                new Building<int>(19,18,22),
                new Building<int>(23,13,29),
                new Building<int>(24,4,28),
                };
            Console.WriteLine("Example in Book:");
            blds.ToList<Building<int>>().ForEach(b => Console.Write("{0} {1} {2},", b[0], b[1], b[2]));
            Console.WriteLine();
            Console.WriteLine("Expected Result:{0}", "1,11,3,13,9,0,12,7,16,3,19,18,22,3,23,13,29,0");
            MergeBuildings(blds);
            #endregion

            #region Test Case 2 随机10万个建筑合并
            Building<int>[] blds2 = initBuildings(100000, 0, 500, 5000);
            Console.WriteLine();
            Console.WriteLine("100 thousands builds:");
            MergeBuildings(blds2);
            #endregion

            Console.ReadKey();
        }
        public static void MergeBuildings(Building<int>[] blds)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start!");
            sw.Start();
            Building<int> nb = OutLineUtility.MergeBuildings<int>(blds, 0, blds.Length - 1);
            sw.Stop();
            Console.WriteLine("Time:{0}s", sw.Elapsed.TotalSeconds);
            nb.Data.ForEach(d => Console.Write(d + " "));
            Console.WriteLine();

        }
        public static Building<int>[] initBuildings(int buildCount, int leftLimitInclusive, int maxHeightLimitInclusive, int rightLimitInclusive)
        {
            Building<int>[] buildings = new Building<int>[buildCount];
            Random rndRange = new Random(DateTime.Now.Millisecond);
            Random rndHeight = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < buildCount; i++)
            {
                int l = rndRange.Next(leftLimitInclusive, rightLimitInclusive);
                int r = rndRange.Next(l + 1, rightLimitInclusive + 1);
                int h = rndHeight.Next(1, maxHeightLimitInclusive + 1);
                Building<int> bld = new Building<int>(l, h, r);
                buildings[i] = bld;
            }
            return buildings;
        }
    }
}
