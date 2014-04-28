using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public class CountingSort : INoneCompareSort
    {
        //计数排序对于最大最小值之差比较小的数据排序比较合适，对于最大最小值之差比较大，
        //且待排序的数值数量比较小的的时候，排序效率会退化。
        //public static void Sort(int[] array, int startIndex, int endIndex)
        //{
        //    int maxValue = array[startIndex];
        //    int minValue = array[startIndex];
        //    if ((endIndex - startIndex + 1) % 2 == 0)//偶数个数据
        //    {
        //        for (int i = startIndex; i <= endIndex; i = i + 2)
        //        {
        //            if (array[i] >= array[i + 1])
        //            {
        //                if (array[i] > maxValue) maxValue = array[i];
        //                if (array[i + 1] < minValue) minValue = array[i + 1];
        //            }
        //            else
        //            {
        //                if (array[i + 1] > maxValue) maxValue = array[i + 1];
        //                if (array[i] < minValue) minValue = array[i];
        //            }
        //        }
        //    }
        //    else//奇数个数据
        //    {
        //        for (int i = startIndex; i <= endIndex - 1; i = i + 2)
        //        {
        //            if (array[i] >= array[i + 1])
        //            {
        //                if (array[i] > maxValue) maxValue = array[i];
        //                if (array[i + 1] < minValue) minValue = array[i + 1];
        //            }
        //            else
        //            {
        //                if (array[i + 1] > maxValue) maxValue = array[i + 1];
        //                if (array[i] < minValue) minValue = array[i];
        //            }
        //        }
        //        if (array[endIndex] > maxValue) maxValue = array[endIndex];
        //        if (array[endIndex] < minValue) minValue = array[endIndex];
        //    }

        //    int[] countingArray = new int[maxValue - minValue + 1];
        //    for (int i = startIndex; i <= endIndex; i++)
        //    {
        //        countingArray[array[i] - minValue]++;
        //    }

        //    for (int i = 1; i < countingArray.Length; i++)
        //    {
        //        countingArray[i] = countingArray[i] + countingArray[i - 1];
        //    }
        //    //取结果放于新数组sortedArray
        //    int[] sortedArray = new int[endIndex - startIndex + 1];
        //    for (int i = endIndex; i >= startIndex; i--)
        //    {
        //        //从后到前扫描原始array数组才能保证排序的稳定性
        //        //设array[i]=a,则设countingArray[a-minValue]=aIndex，aIndex表示在排序好的数组中a是第aIndex个，在数组中的下标应为aIndex-1
        //        //将a放到sortedArray[aIndex-1].countingArray[a]数值减一表示等于a的其它数值的位置向前步进1个位置。
        //        sortedArray[(countingArray[array[i] - minValue]--) - 1] = array[i];
        //    }
        //    for (int i = 0; i < sortedArray.Length; i++)
        //    {
        //        array[i + startIndex] = sortedArray[i];
        //    }
        //}

        public void Sort(int[] array, int startIndex, int endIndex, int minValue, int maxValue)
        {
            int[] countingArray = new int[maxValue - minValue + 1];
            for (int i = startIndex; i <= endIndex; i++)
            {
                countingArray[array[i] - minValue]++;
            }

            for (int i = 1; i < countingArray.Length; i++)
            {
                countingArray[i] = countingArray[i] + countingArray[i - 1];
            }
            //取结果放于新数组sortedArray
            int[] sortedArray = new int[endIndex - startIndex + 1];
            for (int i = endIndex; i >= startIndex; i--)
            {
                //从后到前扫描原始array数组才能保证排序的稳定性
                //设array[i]=a,则设countingArray[a-minValue]=aIndex，aIndex表示在排序好的数组中a是第aIndex个，在数组中的下标应为aIndex-1
                //将a放到sortedArray[aIndex-1].countingArray[a]数值减一表示等于a的其它数值的位置向前步进1个位置。
                sortedArray[(countingArray[array[i] - minValue]--) - 1] = array[i];
            }
            for (int i = 0; i < sortedArray.Length; i++)
            {
                array[i + startIndex] = sortedArray[i];
            }
        }
    }
}
