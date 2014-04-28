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
    public sealed class OldOutLineUtility
    {
        public static OldBuilding[] initBuildings(int buildCount, int leftLimitInclusive, int maxHeightLimitInclusive, int rightLimitInclusive)
        {
            OldBuilding[] buildings = new OldBuilding[buildCount];
            Random rndRange = new Random(DateTime.Now.Millisecond);
            Random rndHeight = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < buildCount; i++)
            {
                int l = rndRange.Next(leftLimitInclusive, rightLimitInclusive);
                int r = rndRange.Next(l + 1, rightLimitInclusive + 1);
                int h = rndHeight.Next(1, maxHeightLimitInclusive + 1);
                OldBuilding bld = new OldBuilding(l, h, r);
                buildings[i] = bld;
            }
            return buildings;
        }
        public static List<Point> MergeBuildings(OldBuilding[] blds, int leftIndex, int rightIndex)
        {
            if (rightIndex - leftIndex <= 1)//one or two buildings
            {
                return mergeTwoBuildingsImpl(blds[leftIndex], blds[rightIndex]);
            }
            else
            {
                int middle = (rightIndex + leftIndex) / 2;
                List<Point> firstOutlines = MergeBuildings(blds, leftIndex, middle);
                List<Point> secondOutlines = MergeBuildings(blds, middle + 1, rightIndex);
                return mergeTwoOutLinesImpl(firstOutlines, secondOutlines);
            }
        }
        private static List<Point> mergeTwoBuildingsImpl(OldBuilding first, OldBuilding second)
        {
            OldBuilding left, right;
            if (Math.Min(first.X1, second.X1) == second.X1)
            {
                left = second;
                right = first;
            }
            else
            {
                left = first;
                right = second;
            }
            List<Point> points = new List<Point>();
            #region Lx1<Lx2<=Rx1<Rx2
            if (left.X2 <= right.X1)
            {
                if (left.X2 < right.X1)
                {
                    points.AddRange(
                        new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H),
                            new Point(left.X2,left.H),
                            new Point(left.X2,0),
                            new Point(right.X1,0),
                            new Point(right.X1,right.H),
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                }
                else//==
                {
                    if (left.H == right.H)
                    {
                        points.AddRange(
                            new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H),                            
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                    else
                    {
                        points.AddRange(
                            new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H),
                            new Point(left.X2,left.H), 
                            new Point(right.X1,right.H),
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                }
            }
            #endregion
            #region Lx1<=Rx1<Lx2<=Rx2
            if (left.X1 <= right.X1 && right.X1 < left.X2 && left.X2 <= right.X2)
            {
                if (left.X1 < right.X1 && left.X2 < right.X2)
                {
                    if (left.H < right.H)
                    {
                        points.AddRange(
                               new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(right.X1,left.H),
                            new Point(right.X1,right.H),
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                    else if (left.H > right.H)
                    {
                        points.AddRange(
                              new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(left.X2,left.H),
                            new Point(left.X2,right.H),
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                    else//==
                    {
                        points.AddRange(
                                new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H),                             
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                }
                if (left.X1 == right.X1 && left.X2 < right.X2)
                {
                    if (left.H <= right.H)
                    {
                        points.AddRange(
                               new List<Point>()
                        {
                            new Point(right.X1,0),
                            new Point(right.X1,right.H), 
                            new Point(right.X2,right.H),                           
                            new Point(right.X2,0),
                        });
                    }
                    else
                    {
                        points.AddRange(
                              new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(left.X2,left.H),
                            new Point(left.X2,right.H),
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                }
                if (left.X1 < right.X1 && left.X2 == right.X2)
                {
                    if (left.H >= right.H)
                    {
                        points.AddRange(
                               new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(left.X2,left.H),                           
                            new Point(left.X2,0),
                        });
                    }
                    else
                    {
                        points.AddRange(
                              new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(right.X1,left.H),
                            new Point(right.X1,right.H),
                            new Point(right.X2,right.H),
                            new Point(right.X2,0),
                        });
                    }
                }
                if (left.X1 == right.X1 && left.X2 == right.X2)
                {
                    points.AddRange(
                               new List<Point>()
                        {
                            new Point(right.X1,0),
                            new Point(right.X1,Math.Max(left.H,right.H)), 
                            new Point(right.X2,Math.Max(left.H,right.H)),                           
                            new Point(right.X2,0),
                        });
                }
            }
            #endregion
            #region Lx1<=Rx1<Rx2<=Lx2
            if (left.X1 <= right.X1 && right.X2 <= left.X2)
            {
                //if (left.X1 == right.X1 && right.X2 == left.X2)
                //{
                //    points.AddRange(
                //                   new List<Point>()
                //        {
                //            new Point(right.X1,0),
                //            new Point(right.X1,Math.Max(left.H,right.H)), 
                //            new Point(right.X2,Math.Max(left.H,right.H)),                           
                //            new Point(right.X2,0),
                //        });
                //}
                if (left.X1 < right.X1 && right.X2 < left.X2)
                {
                    if (right.H <= left.H)
                    {
                        points.AddRange(
                                       new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(left.X2,left.H),                           
                            new Point(left.X2,0),
                        });
                    }
                    else
                    {
                        points.AddRange(
                                           new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(right.X1,left.H), 
                            new Point(right.X1,right.H),                           
                            new Point(right.X2,right.H),
                            new Point(right.X2,left.H),
                            new Point(left.X2,left.H), 
                            new Point(left.X2,0),
                        });
                    }
                }
                //if (left.X1 < right.X1 && right.X2 == left.X2)
                //{
                //    if (right.H <= left.H)
                //    {
                //        points.AddRange(
                //                       new List<Point>()
                //        {
                //            new Point(left.X1,0),
                //            new Point(left.X1,left.H), 
                //            new Point(left.X2,left.H),                           
                //            new Point(left.X2,0),
                //        });
                //    }
                //    else
                //    {
                //        points.AddRange(
                //                       new List<Point>()
                //        {
                //            new Point(left.X1,0),
                //            new Point(left.X1,left.H), 
                //            new Point(right.X1,left.H), 
                //            new Point(right.X1,right.H),
                //            new Point(right.X2,right.H),                           
                //            new Point(right.X2,0),
                //        });
                //    }
                //}
                if (left.X1 == right.X1 && right.X2 < left.X2)
                {
                    if (right.H <= left.H)
                    {
                        points.AddRange(
                                       new List<Point>()
                        {
                            new Point(left.X1,0),
                            new Point(left.X1,left.H), 
                            new Point(left.X2,left.H),                           
                            new Point(left.X2,0),
                        });
                    }
                    else
                    {
                        points.AddRange(
                                       new List<Point>()
                        {
                            new Point(right.X1,0),
                            new Point(right.X1,right.H), 
                            new Point(right.X2,right.H), 
                            new Point(right.X2,left.H),
                            new Point(left.X2,left.H),                           
                            new Point(left.X2,0),
                        });
                    }
                }
            }
            #endregion
            return points;
        }
        private static List<Point> mergeTwoOutLinesImpl(List<Point> L1, List<Point> L2)
        {
            int cursorL = 0;
            int cursorR = 0;
            int min = Convert.ToInt32(Math.Min(L1[0].X, L2[0].X));
            int max = Convert.ToInt32(Math.Max(L1.Last().X, L2.Last().X));
            List<Point> points = new List<Point>();
            points.Add(new Point(min, 0));
            for (double x = min; x <= max; x = x + 0.5)
            {
                int y1 = -1, y2 = -1;
                if (cursorL <= L1.Count - 2)
                {
                    if (L1[cursorL].X == x && L1[cursorL].X == L1[cursorL + 1].X)
                    {
                        y1 = Math.Max(L1[cursorL].Y, L1[cursorL + 1].Y);
                        cursorL = cursorL + 2;

                    }
                    else if (x > L1[0].X && x < L1[cursorL].X)
                    {
                        y1 = L1[cursorL].Y;
                    }
                }
                if (cursorR <= L2.Count - 2)
                {
                    if (L2[cursorR].X == x && L2[cursorR].X == L2[cursorR + 1].X)
                    {
                        y2 = Math.Max(L2[cursorR].Y, L2[cursorR + 1].Y);
                        cursorR = cursorR + 2;

                    }
                    else if (x > L2[0].X && x < L2[cursorR].X)
                    {
                        y2 = L2[cursorR].Y;
                    }
                }

                if (points.Count >= 3)
                {
                    //当前水平线上已经存在两个等高的点，此时只需修改第二个点的x坐标以延伸水平线，此种情况不需要拐点
                    if (points[points.Count - 1].Y == points[points.Count - 2].Y && points[points.Count - 1].Y == Math.Max(y1, y2))
                    {
                        points[points.Count - 1].X = x;
                    }
                    else//此时需添加拐点，分为两种情况，一种是新添加的点与拐点x坐标相同，另一种是y坐标相同
                    {
                        //第一种情况，新的y值大于上一个点的y
                        if (Math.Max(y1, y2) > points[points.Count - 1].Y)
                        {
                            if (points[points.Count - 1].Y == points[points.Count - 2].Y)
                            {
                                points[points.Count - 1].X = x;//水平线上已经存在两个点，改造第二个点x坐标到拐点位置
                            }
                            else
                            {
                                points.Add(new Point(x, points[points.Count - 1].Y));//新拐点
                            }
                        }
                        //第二种情况，新的y值小于上一个点的y
                        if (Math.Max(y1, y2) < points[points.Count - 1].Y)
                        {
                            points.Add(new Point(points[points.Count - 1].X, Math.Max(y1, y2)));//新拐点
                        }
                        points.Add(new Point(x, Math.Max(y1, y2)));//添加水平线的第2个点
                    }
                }
                else
                {
                    points.Add(new Point(x, Math.Max(y1, y2)));
                }
            }
            points.Add(new Point(max, 0));
            return points;
        }
        //第二种算法
        public static List<Point> MergeBuildings2(List<Point>[] bldsOutline, int leftIndex, int rightIndex)
        {
            if (rightIndex - leftIndex <= 1)//one or two buildings
            {
                return mergeTwoOutLinesImpl(bldsOutline[leftIndex], bldsOutline[rightIndex]);
            }
            else
            {
                int middle = (rightIndex + leftIndex) / 2;
                List<Point> firstOutlines = MergeBuildings2(bldsOutline, leftIndex, middle);
                List<Point> secondOutlines = MergeBuildings2(bldsOutline, middle + 1, rightIndex);
                return mergeTwoOutLinesImpl(firstOutlines, secondOutlines);
            }
        }
        public static List<Point> convertSingleBuilding2Outline(OldBuilding bld)
        {
            return new List<Point>() 
            {
            new Point(bld.X1,0),
              new Point(bld.X1,bld.H),
                new Point(bld.X2,bld.H),
                  new Point(bld.X2,0),            
            };

        }
        private static void OutputOutlineToConsole(List<Point> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(result[i].X);
                    Console.Write(" ");
                }
                if (i % 2 == 1)
                {
                    Console.Write(result[i].Y);
                    Console.Write(" ");
                }
            }
        }
    }
}
