using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.DataStructure
{
    public class MaxPriorityQueue<T1, T2>
        where T1 : IComparable<T1>
        where T2 : IComparable<T2>
    {
        private T1[] array;
        private int cursor;
        public MaxPriorityQueue()
        {
            array = new T1[32];
            cursor = 0;
        }
        public void Insert(T1 x)
        {
            if (array.Count() == cursor + 1)
            {
                T1[] tmparray = new T1[array.Count() * 2];
                array.CopyTo(tmparray, 0);
                array = tmparray;
            }
            array[cursor++] = x;


        }
        public T1 Maximum(T1[] S)
        {
            return S[0];
        }
        public T1 ExtractMax(T1[] S)
        {
            return S[0];
        }
        public T1[] IncreaseKey(T1[] S, T1 x, T2 newValue)
        {
            return new T1[1];
        }
        //private void maxHeapify(T1[] array, int startIndex, int endIndex, int newRootIndex)
        //{

        //    //int L = (newRootIndex - startIndex) * 2 + 1 + startIndex;
        //    int L = (newRootIndex - startIndex + 1) * 2 + startIndex - 1;//The array base is from 0.
        //    int R = L + 1;
        //    int tmpLargestIndex = newRootIndex;
        //    if (L <= endIndex && array[L].CompareTo(array[tmpLargestIndex]) > 0)
        //    {
        //        tmpLargestIndex = L;
        //    }
        //    if (R <= endIndex && array[R].CompareTo(array[tmpLargestIndex]) > 0)
        //    {
        //        tmpLargestIndex = R;
        //    }
        //    if (tmpLargestIndex != newRootIndex)
        //    {
        //        //swap array[tmpLargestIndex] and array[newRootIndex]
        //        T tmpT = array[tmpLargestIndex];
        //        array[tmpLargestIndex] = array[newRootIndex];
        //        array[newRootIndex] = tmpT;
        //        //MaxHeapify the child branch, the newRootIndex= tmpLargestIndex
        //        maxHeapify(array, startIndex, endIndex, tmpLargestIndex);
        //    }
        //}
    }
}
