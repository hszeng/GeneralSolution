using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public interface INoneCompareSort
    {
        void Sort(int[] array, int startIndex, int endIndex, int minValue, int maxValue);
    }
}
