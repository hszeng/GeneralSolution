using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public interface ISort<T> where T : IComparable<T>
    {
        void Sort(T[] array, int startIndex, int endIndex);
    }
}
