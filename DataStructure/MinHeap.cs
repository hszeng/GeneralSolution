using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.DataStructure
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private MinHeap() { }
        public MinHeap(T[] array, int startIndex, int endIndex)
        {
            InternalDataArray = array;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
            //Heapify the array
            buildMinHeap(array, startIndex, endIndex);
        }
        public T[] InternalDataArray { get; private set; }
        public int startIndex { get; private set; }
        public int endIndex { get; private set; }
        private void buildMinHeap(T[] array, int startIndex, int endIndex)
        {
            //Leaf node is from (endIndex-startIndex+1)/2+1+startIndex to endIndex
            // //O(n*Log(n))
            for (int i = (endIndex - startIndex + 1) / 2 + startIndex; i >= startIndex; i--)
            {
                //O(Log(n))
                minHeapify(array, startIndex, endIndex, i);
            }
        }
        //insert a new root node for two child maxHeap.
        private void minHeapify(T[] array, int startIndex, int endIndex, int newRootIndex)
        {

            //int L = (newRootIndex - startIndex) * 2 + 1 + startIndex;
            int L = (newRootIndex - startIndex + 1) * 2 + startIndex - 1;//The array base is from 0.
            int R = L + 1;
            int tmpSmallestIndex = newRootIndex;
            if (L <= endIndex && array[L].CompareTo(array[tmpSmallestIndex]) < 0)
            {
                tmpSmallestIndex = L;
            }
            if (R <= endIndex && array[R].CompareTo(array[tmpSmallestIndex]) < 0)
            {
                tmpSmallestIndex = R;
            }
            if (tmpSmallestIndex != newRootIndex)
            {
                //swap array[tmpLargestIndex] and array[newRootIndex]
                T tmpT = array[tmpSmallestIndex];
                array[tmpSmallestIndex] = array[newRootIndex];
                array[newRootIndex] = tmpT;
                //MaxHeapify the child branch, the newRootIndex= tmpLargestIndex
                minHeapify(array, startIndex, endIndex, tmpSmallestIndex);
            }
        }
    }
}
