using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Outline
{
    /// <summary>
    /// Project:Outline
    /// Author: Zeng Huansheng
    /// Email:andyzengsh@gmail.com 
    /// Date:2014/04/12
    /// </summary>
    public sealed class OutLineUtility
    {
        //新算法
        public static Building<T> MergeBuildings<T>(Building<T>[] blds, int leftIndex, int rightIndex) where T : IComparable<T>
        {
            var bld = InternalMergeBuildings<T>(blds, leftIndex, rightIndex);
            bld.Data.Add(default(T));
            return bld;
        }

        private static Building<T> InternalMergeBuildings<T>(Building<T>[] blds, int leftIndex, int rightIndex) where T : IComparable<T>
        {
            if (rightIndex - leftIndex <= 1)//one or two buildings
            {
                return MergeTwoBuildingsImpl(blds[leftIndex], blds[rightIndex]);
            }
            else
            {
                int middle = (rightIndex + leftIndex) / 2;
                Building<T> firstOutlines = InternalMergeBuildings(blds, leftIndex, middle);
                Building<T> secondOutlines = InternalMergeBuildings(blds, middle + 1, rightIndex);
                return MergeTwoBuildingsImpl(firstOutlines, secondOutlines);
            }
        }
        private static Building<T> MergeTwoBuildingsImpl<T>(Building<T> A, Building<T> B) where T : IComparable<T>
        {
            Building<T> nb = new Building<T>();
            int cursorA = 0;//the cursor for the first building
            int cursorB = 0;////the cursor for the second building
            T ax1, ah, ax2, bx1, bh, bx2;
            int lenthA = A.Data.Count, lenthB = B.Data.Count;//长度都必为
            T kneePointX = A[cursorA].CompareTo(B[cursorB]) >= 0 ? B[cursorB] : A[cursorA];//拐点
            while (cursorA < lenthA || cursorB < lenthB)
            {
                //边界情况
                if (cursorA == lenthA - 1 && cursorB == lenthB - 1)
                {
                    nb.Data.Add(A[cursorA].CompareTo(B[cursorB]) >= 0 ? A[cursorA] : B[cursorB]);
                    break;
                }

                if (cursorA >= lenthA - 1)
                {
                    ax1 = A[lenthA - 1]; ah = default(T); ax2 = ax1;
                }
                else
                {
                    ax1 = A[cursorA]; ah = A[cursorA + 1]; ax2 = A[cursorA + 2];
                }
                if (cursorB >= lenthB - 1)
                {
                    bx1 = B[lenthB - 1]; bh = default(T); bx2 = bx1;
                }
                else
                {
                    bx1 = B[cursorB]; bh = B[cursorB + 1]; bx2 = B[cursorB + 2];
                }
                //高度取当前x<=currentX<=x2的建筑高度的最大值
                //int h = (Math.Max(ax1 <= kneePointX && kneePointX <= ax2 ? ah : 0, bx1 <= kneePointX && kneePointX <= bx2 ? bh : 0));
                T a = ax1.CompareTo(kneePointX) <= 0 && kneePointX.CompareTo(ax2) <= 0 ? ah : default(T);
                T b = bx1.CompareTo(kneePointX) <= 0 && kneePointX.CompareTo(bx2) <= 0 ? bh : default(T);
                T h = a.CompareTo(b) >= 0 ? a : b;

                if ((nb.Data.Count == 0) || (nb.Data.Count > 0 && nb.Data.Last().CompareTo(h) != 0))//第一个点或者与前面的轮廓不等高点才添加新的轮廓
                {
                    //x点取kneePointX，封闭前面的轮廓，加入新的高度
                    nb.Data.Add(kneePointX);
                    nb.Data.Add(h);
                }
                //关键,下一个拐点的取法：取大于kneePointX的最小点 
                kneePointX = getKneePoint(new T[] { ax1, ax2, bx1, bx2 }, kneePointX);
                //关键：检查两个轮廓的游标是否需要向前步进
                if (ax2.CompareTo(kneePointX) <= 0 && cursorA < lenthA - 1) cursorA = cursorA + 2;
                if (bx2.CompareTo(kneePointX) <= 0 && cursorB < lenthB - 1) cursorB = cursorB + 2;
            }
            return nb;
        }
        private static T getKneePoint<T>(T[] arr, T kneePointX) where T : IComparable<T>
        {
            T minMax = kneePointX;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(kneePointX) > 0)
                {
                    if (minMax.CompareTo(kneePointX) == 0)//得到第一个大于kneePoint的数
                    {
                        minMax = arr[i];
                    }
                    else
                    {
                        if (arr[i].CompareTo(minMax) < 0)
                        {
                            minMax = arr[i];
                        }
                    }
                }
            }
            return minMax;
        }
    }
}
