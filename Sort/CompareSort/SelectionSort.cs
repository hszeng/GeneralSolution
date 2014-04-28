using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public class SelectionSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(T[] array, int startIndex, int endIndex)
        {
            for (int i = endIndex; i >= startIndex; i--)
            {
                int maxIndex = startIndex;
                for (int j = startIndex; j <= i; j++)
                {
                    if (array[j].CompareTo(array[maxIndex]) >= 0)
                    {
                        maxIndex = j;
                    }
                }
                T tmp = array[i];
                array[i] = array[maxIndex];
                array[maxIndex] = tmp;
            }
        }
    }
}
