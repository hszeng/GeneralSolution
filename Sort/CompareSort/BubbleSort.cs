using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public class BubbleSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(T[] array, int startIndex, int endIndex)
        {
            bool isMoved = false;
            for (int i = endIndex; i >= startIndex; i--)
            {
                for (int j = startIndex; j < i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        T v = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = v;
                        isMoved = true;
                    }
                }
                if (isMoved == false) break;
            }
        }
    }
}
