using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Maxsubsequence
{
    class MaxSubsequenceUtil
    {
        public static double FindMaxSubsequence(double[] array, out int startIndex)
        {
            double GlobeMax = 0, tmpMax = 0;
            startIndex = -1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                tmpMax = tmpMax + array[i];
                if (GlobeMax < tmpMax)
                {
                    GlobeMax = tmpMax;
                    startIndex = i;
                }
                else if (tmpMax < 0)
                {
                    tmpMax = 0;
                }
            }
            return GlobeMax;
        }
    }
}
