using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public class InsertionSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(T[] array, int startIndex, int endIndex)
        {
            //假定startIndex的值已经在正确位置
            for (int i = startIndex; i <= endIndex; i++)
            {
                T tmp = array[i];//待插入数据
                int targetIndex = i;//当前位置为寻找起点
                while (targetIndex > startIndex && array[targetIndex - 1].CompareTo(tmp) > 0)
                {
                    array[targetIndex] = array[targetIndex - 1];//已排好顺序的序列依次向右移位  
                    targetIndex--;//此待选位置空出
                }
                array[targetIndex] = tmp;
            }
        }
    }
}
