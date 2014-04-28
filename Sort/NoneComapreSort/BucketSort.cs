using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Sort
{
    public class BucketSort
    {
        public static void Sort(int[] array, int startIndex, int endIndex)
        {
            int maxValue = array[startIndex];
            int minValue = array[startIndex];
            if ((endIndex - startIndex + 1) % 2 == 0)//偶数个数据
            {
                for (int i = startIndex; i <= endIndex; i = i + 2)
                {
                    if (array[i] >= array[i + 1])
                    {
                        if (array[i] > maxValue) maxValue = array[i];
                        if (array[i + 1] < minValue) minValue = array[i + 1];
                    }
                    else
                    {
                        if (array[i + 1] > maxValue) maxValue = array[i + 1];
                        if (array[i] < minValue) minValue = array[i];
                    }
                }
            }
            else//奇数个数据
            {
                for (int i = startIndex; i <= endIndex - 1; i = i + 2)
                {
                    if (array[i] >= array[i + 1])
                    {
                        if (array[i] > maxValue) maxValue = array[i];
                        if (array[i + 1] < minValue) minValue = array[i + 1];
                    }
                    else
                    {
                        if (array[i + 1] > maxValue) maxValue = array[i + 1];
                        if (array[i] < minValue) minValue = array[i];
                    }
                }
                if (array[endIndex] > maxValue) maxValue = array[endIndex];
                if (array[endIndex] < minValue) minValue = array[endIndex];
            }
            //因为桶排序一般知道数值范围，但是为了测试通用性，前面的代码是自己自己计算最大最小值
            //本例中数据范围是0~10000
            //按照数值的大小分成10个桶，然后求出每个区间的数值个数构造每个区间的实际存储桶
            int gap = ((maxValue - minValue + 1) / 10) + 1;
            //区间 [minValue，minValue+gap），[minValue+gap，minValue+2*gap）...[minValue+8*gap,minValue+9*gap),[minValue+10*gap,maxValue+1)
            int[] sizeCounter = new int[10];
            for (int i = startIndex; i <= endIndex; i++)
            {
                sizeCounter[array[i] / gap]++;
            }
            //定义每个桶的大小
            int[][] Buckets = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                Buckets[i] = new int[sizeCounter[i]];
            }
            int[] BucketsCursor = new int[10];

            for (int i = startIndex; i <= endIndex; i++)
            {
                int bucketIndex = array[i] / gap;
                Buckets[bucketIndex][BucketsCursor[bucketIndex]++] = array[i];
            }
            for (int i = 0; i < 10; i++)
            {
                (new CountingSort()).Sort(Buckets[i], 0, Buckets[i].Length - 1, i * gap, (i + 1) * gap);
            }
            //填充返回的数据
            int cursor = startIndex;
            for (int i = 0; i < 10; i++)
            {
                int bucketSize = Buckets[i].Length;
                for (int j = 0; j < bucketSize; j++)
                {
                    array[cursor++] = Buckets[i][j];
                }
            }
        }
        public static void ParallelSort(int[] array, int startIndex, int endIndex)
        {
            int maxValue = array[startIndex];
            int minValue = array[startIndex];
            if ((endIndex - startIndex + 1) % 2 == 0)//偶数个数据
            {
                for (int i = startIndex; i <= endIndex; i = i + 2)
                {
                    if (array[i] >= array[i + 1])
                    {
                        if (array[i] > maxValue) maxValue = array[i];
                        if (array[i + 1] < minValue) minValue = array[i + 1];
                    }
                    else
                    {
                        if (array[i + 1] > maxValue) maxValue = array[i + 1];
                        if (array[i] < minValue) minValue = array[i];
                    }
                }
            }
            else//奇数个数据
            {
                for (int i = startIndex; i <= endIndex - 1; i = i + 2)
                {
                    if (array[i] >= array[i + 1])
                    {
                        if (array[i] > maxValue) maxValue = array[i];
                        if (array[i + 1] < minValue) minValue = array[i + 1];
                    }
                    else
                    {
                        if (array[i + 1] > maxValue) maxValue = array[i + 1];
                        if (array[i] < minValue) minValue = array[i];
                    }
                }
                if (array[endIndex] > maxValue) maxValue = array[endIndex];
                if (array[endIndex] < minValue) minValue = array[endIndex];
            }
            //因为桶排序一般知道数值范围，但是为了测试通用性，前面的代码是自己自己计算最大最小值
            //本例中数据范围是0~10000
            //按照数值的大小分成10个桶，然后求出每个区间的数值个数构造每个区间的实际存储桶
            int gap = ((maxValue - minValue + 1) / 10) + 1;
            //区间 [minValue，minValue+gap），[minValue+gap，minValue+2*gap）...[minValue+8*gap,minValue+9*gap),[minValue+10*gap,maxValue+1)
            int[] sizeCounter = new int[10];
            for (int i = startIndex; i <= endIndex; i++)
            {
                sizeCounter[array[i] / gap]++;
            }
            //定义每个桶的大小
            int[][] Buckets = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                Buckets[i] = new int[sizeCounter[i]];
            }
            int[] BucketsCursor = new int[10];

            for (int i = startIndex; i <= endIndex; i++)
            {
                int bucketIndex = array[i] / gap;
                Buckets[bucketIndex][BucketsCursor[bucketIndex]++] = array[i];
            }

            Action[] acts = new Action[10];
            for (int i = 0; i < 10; i++)
            {
                int x = i;
                acts[x] = new Action(() => (new CountingSort()).Sort(Buckets[x], 0, Buckets[x].Length - 1, i * gap, (i + 1) * gap));
            }
            System.Threading.Tasks.Parallel.Invoke(acts);
            //填充返回的数据
            int cursor = startIndex;
            for (int i = 0; i < 10; i++)
            {
                int bucketSize = Buckets[i].Length;
                for (int j = 0; j < bucketSize; j++)
                {
                    array[cursor++] = Buckets[i][j];
                }
            }
        }
    }
}
