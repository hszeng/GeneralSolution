using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.OrderStatistics
{
    public class MinMaxFinder<T> where T : IComparable<T>
    {
        public void FindMinMax(T[] array, int startIndex, int endIndex, out T minValue, out T maxValue)
        {
            maxValue = array[startIndex];
            minValue = array[startIndex];
            if ((endIndex - startIndex + 1) % 2 == 0)//偶数个数据
            {
                for (int i = startIndex; i <= endIndex; i = i + 2)
                {
                    if (array[i].CompareTo(array[i + 1]) >= 0)
                    {
                        if (array[i].CompareTo(maxValue) > 0) maxValue = array[i];
                        if (array[i + 1].CompareTo(minValue) < 0) minValue = array[i + 1];
                    }
                    else
                    {
                        if (array[i + 1].CompareTo(maxValue) > 0) maxValue = array[i + 1];
                        if (array[i].CompareTo(minValue) < 0) minValue = array[i];
                    }
                }
            }
            else//奇数个数据
            {
                for (int i = startIndex; i <= endIndex-1; i = i + 2)
                {
                    if (array[i].CompareTo(array[i + 1]) >= 0)
                    {
                        if (array[i].CompareTo(maxValue) > 0) maxValue = array[i];
                        if (array[i + 1].CompareTo(minValue) < 0) minValue = array[i + 1];
                    }
                    else
                    {
                        if (array[i + 1].CompareTo(maxValue) > 0) maxValue = array[i + 1];
                        if (array[i].CompareTo(minValue) < 0) minValue = array[i];
                    }
                }
                if (array[endIndex].CompareTo(maxValue) > 0) maxValue = array[endIndex];
                if (array[endIndex].CompareTo(minValue) < 0) minValue = array[endIndex];
            }
        }
    }
}
