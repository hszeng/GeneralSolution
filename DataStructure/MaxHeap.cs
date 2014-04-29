using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.DataStructure
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private MaxHeap() { }
        public MaxHeap(T[] array, int startIndex, int endIndex)
        {
            InternalDataArray = array;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
            //Heapify the array
            buildMaxHeap(array, startIndex, endIndex);
        }
        public T[] InternalDataArray { get; private set; }
        public int startIndex { get; private set; }
        public int endIndex { get; private set; }
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
        private void maxHeapify(T[] array, int startIndex, int endIndex, int nodeIndex)
        {

            //int L = (newRootIndex - startIndex) * 2 + 1 + startIndex;
            int L = (nodeIndex - startIndex + 1) * 2 + startIndex - 1;//The array base is from 0.
            int R = L + 1;
            int tmpLargestIndex = nodeIndex;
            if (L <= endIndex && array[L].CompareTo(array[tmpLargestIndex]) > 0)
            {
                tmpLargestIndex = L;
            }
            if (R <= endIndex && array[R].CompareTo(array[tmpLargestIndex]) > 0)
            {
                tmpLargestIndex = R;
            }
            if (tmpLargestIndex != nodeIndex)
            {
                //swap array[tmpLargestIndex] and array[newRootIndex]
                T tmpT = array[tmpLargestIndex];
                array[tmpLargestIndex] = array[nodeIndex];
                array[nodeIndex] = tmpT;
                //MaxHeapify the child branch, the newRootIndex= tmpLargestIndex
                maxHeapify(array, startIndex, endIndex, tmpLargestIndex);
            }
        }
    }
}
