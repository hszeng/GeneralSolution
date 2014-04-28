using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction2Algorithms.Sort
{
    public class QuickSortParallel<T> : ISort<T> where T : IComparable<T>
    {
        private InsertionSort<T> insertSort;
        public QuickSortParallel()
        {
            insertSort = new InsertionSort<T>();
        }
        public void Sort(T[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                if (endIndex - startIndex <= (endIndex - startIndex) / 1000)
                {
                    insertSort.Sort(array, startIndex, endIndex);
                    return;
                }
                int pivot = Partition(array, startIndex, endIndex);
                Parallel.Invoke(() => Sort(array, startIndex, pivot - 1), () => Sort(array, pivot + 1, endIndex));
            }
        }
        public static int Partition(T[] array, int leftIndex, int rightIndex)
        {
            //leftIndex的位置空出来了
            T pivotValue = array[leftIndex];
            //将所有<pivotValue的值移动到pivotValue的左边（不稳定排序，因为相等值得相对位置可能被此步骤改变）
            //将所有>=pivotValue的值移到右边
            //移动的结果就是所有<pivotValue的值都在pivotValue的左边，>=它的都在右边
            //记录之后pivotValue所在位置，返回该位置，完成一次分区划分。
            while (leftIndex < rightIndex)
            {
                //因为是leftIndex先空出来位置，所以第一步要从右侧rightIndex向左寻找小于pivotValue的数值位置
                while (leftIndex < rightIndex && array[rightIndex].CompareTo(pivotValue) >= 0) rightIndex--;
                //将找到的小于pivotValue的位置的元素放到空出的leftIndex位置，leftIndex++
                if (leftIndex < rightIndex) array[leftIndex++] = array[rightIndex];
                //leftIndex向右寻找>=pivotValue的值的位置
                while (leftIndex < rightIndex && array[leftIndex].CompareTo(pivotValue) < 0) leftIndex++;
                //将找到的>=pivotValue的位置的leftIndex元素放到上一步空出的rightIndex位置
                //此时leftIndex所在位置变成待插入位置，重新回到外圈循坏的初始状态
                if (leftIndex < rightIndex) array[rightIndex--] = array[leftIndex];
            }
            //最后while循环结束的位置就是leftIndex==rightIndex，并且这个位置是空出来的，正好把pivotValue放到这个位置
            //这就是轴的概念，轴两边的值时由轴正好分开的，一边小于轴，一边大于等于轴
            array[leftIndex] = pivotValue;
            return leftIndex;
        }
    }
}
