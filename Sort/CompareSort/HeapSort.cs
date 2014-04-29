using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public class HeapSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(T[] array, int startIndex, int endIndex)
        {
            //Heapify the array
            buildMaxHeap(array, startIndex, endIndex);
            //Sort from endIndex to (startIndex-1), 
            //when i=startIndex, then only one node left,then no any requirement to heapify it.
            for (int i = endIndex; i > startIndex; i--)
            {
                //swap array[i] and array[startIndex]
                T tmpT = array[i];
                array[i] = array[startIndex];
                array[startIndex] = tmpT;
                maxHeapify(array, startIndex, i - 1, startIndex);
            }
        }
        private void buildMaxHeap(T[] array, int startIndex, int endIndex)
        {
            //Leaf node is from (endIndex-startIndex+1)/2+1+startIndex to endIndex
            // //O(n*Log(n))
            for (int i = (endIndex - startIndex + 1) / 2 + startIndex; i >= startIndex; i--)
            {
                //O(Log(n))
                maxHeapify(array, startIndex, endIndex, i);
            }
        }

        //insert a new root node for two child maxHeap.
        private void maxHeapify(T[] array, int startIndex, int endIndex, int newRootIndex)
        {

            //int L = (newRootIndex - startIndex) * 2 + 1 + startIndex;
            int L = (newRootIndex - startIndex + 1) * 2 + startIndex - 1;//The array base is from 0.
            int R = L + 1;
            int tmpLargestIndex = newRootIndex;
            if (L <= endIndex && array[L].CompareTo(array[tmpLargestIndex]) > 0)
            {
                tmpLargestIndex = L;
            }
            if (R <= endIndex && array[R].CompareTo(array[tmpLargestIndex]) > 0)
            {
                tmpLargestIndex = R;
            }
            if (tmpLargestIndex != newRootIndex)
            {
                //swap array[tmpLargestIndex] and array[newRootIndex]
                T tmpT = array[tmpLargestIndex];
                array[tmpLargestIndex] = array[newRootIndex];
                array[newRootIndex] = tmpT;
                //MaxHeapify the child branch, the newRootIndex= tmpLargestIndex
                maxHeapify(array, startIndex, endIndex, tmpLargestIndex);
            }
        }
    }
}
