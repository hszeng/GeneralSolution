using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.DataStructure
{
    //public class MaxPriorityQueue<TNode, TValue>
    //    where TNode : IHeapValue<TValue>
    //    where TValue : int, double, byte
    //{
    //    private TNode[] array;
    //    private int cursor;
    //    public MaxPriorityQueue()
    //    {
    //        array = new TNode[32];
    //        cursor = 0;
    //    }
    //    public void Insert(TNode x)
    //    {
    //        if (cursor + 1 == array.Count())
    //        {
    //            TNode[] tmparray = new TNode[array.Count() * 2];
    //            array.CopyTo(tmparray, 0);
    //            array = tmparray;
    //        }
    //        array[cursor++] = x;


    //    }
    //    public TNode Maximum()
    //    {

    //        return array[0];
    //    }
    //    public TNode ExtractMax()
    //    {
    //        return array[0];
    //    }
    //    public TNode[] IncreaseKey(TNode[] S, TNode x, TNode newValue)
    //    {
    //        return new TNode[1];
    //    }
    //    private void maxHeapify(TNode[] array, int startIndex, int endIndex, int newRootIndex)
    //    {

    //        //int L = (newRootIndex - startIndex) * 2 + 1 + startIndex;
    //        int L = (newRootIndex - startIndex + 1) * 2 + startIndex - 1;//The array base is from 0.
    //        int R = L + 1;
    //        int tmpLargestIndex = newRootIndex;
    //        if (L <= endIndex && array[L].Value.CompareTo(array[tmpLargestIndex].Value)>0)
    //        {
    //            tmpLargestIndex = L;
    //        }
    //        if (R <= endIndex && array[R].Value.CompareTo(array[tmpLargestIndex].Value) > 0)
    //        {
    //            tmpLargestIndex = R;
    //        }
    //        if (tmpLargestIndex != newRootIndex)
    //        {
    //            //swap array[tmpLargestIndex] and array[newRootIndex]
    //            TNode tmpT = array[tmpLargestIndex];
    //            array[tmpLargestIndex] = array[newRootIndex];
    //            array[newRootIndex] = tmpT;
    //            //MaxHeapify the child branch, the newRootIndex= tmpLargestIndex
    //            maxHeapify(array, startIndex, endIndex, tmpLargestIndex);
    //        }
    //    }
    //}
}
