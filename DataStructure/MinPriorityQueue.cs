using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.DataStructure
{
    public class MinPriorityQueue<TNode>
        where TNode : IHeapValue
    {
        private TNode[] array;
        //cursor 指向第一个空出来的位置
        private int cursor;
        public MinPriorityQueue()
        {
            array = new TNode[32];
            cursor = 0;
        }
        public bool IsEmpty { get { return cursor <= 0; } }
        public void Insert(TNode x)
        {
            if (cursor + 1 == array.Count())
            {
                TNode[] tmparray = new TNode[array.Count() * 2];
                array.CopyTo(tmparray, 0);
                array = tmparray;
            }
            //往上检查是否成最小堆
            int xIndex = cursor++;
            array[xIndex] = x;
            while (xIndex / 2 >= 0)
            {
                if (array[xIndex / 2].Value <= array[xIndex].Value) break;
                TNode tmpNode = array[xIndex / 2];
                array[xIndex / 2] = array[xIndex];
                array[xIndex] = tmpNode;
                xIndex = xIndex / 2;
            }
        }
        public TNode Minimum()
        {
            return array[0];
        }
        public TNode ExtractMin()
        {
            TNode hn = array[0];
            //把最后一个元素换到第一个 array[0]= array[cursor-1]，array[cursor-1]=null;cursor--；
            array[0] = array[cursor - 1];
            array[cursor - 1] = default(TNode);
            cursor--;
            minHeapify(0, cursor - 1, 0);
            return hn;
        }
        public void DecreaseKey(int nodeIndex, int newValue)
        {
            if (nodeIndex < cursor && array[nodeIndex].Value < newValue)
            {
                array[nodeIndex].Value = newValue;
                while (nodeIndex / 2 >= 0)
                {
                    if (array[nodeIndex / 2].Value <= array[nodeIndex].Value) break;
                    TNode tmpNode = array[nodeIndex / 2];
                    array[nodeIndex / 2] = array[nodeIndex];
                    array[nodeIndex] = tmpNode;
                    nodeIndex = nodeIndex / 2;
                }
            }

        }
        //由下向上建堆时使用此函数，下面已经建好，上面还没好时使用
        private void minHeapify(int startIndex, int endIndex, int newRootIndex)
        {

            //int L = (newRootIndex - startIndex) * 2 + 1 + startIndex;
            int L = (newRootIndex - startIndex + 1) * 2 + startIndex - 1;//The array base is from 0.
            int R = L + 1;
            int tmpLargestIndex = newRootIndex;
            if (L <= endIndex && array[L].Value.CompareTo(array[tmpLargestIndex].Value) < 0)
            {
                tmpLargestIndex = L;
            }
            if (R <= endIndex && array[R].Value.CompareTo(array[tmpLargestIndex].Value) < 0)
            {
                tmpLargestIndex = R;
            }
            if (tmpLargestIndex != newRootIndex)
            {
                //swap array[tmpLargestIndex] and array[newRootIndex]
                TNode tmpT = array[tmpLargestIndex];
                array[tmpLargestIndex] = array[newRootIndex];
                array[newRootIndex] = tmpT;
                //MaxHeapify the child branch, the newRootIndex= tmpLargestIndex
                minHeapify(startIndex, endIndex, tmpLargestIndex);
            }
        }
    }
}
