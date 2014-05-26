using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introduction2Algorithms.Sort;

namespace Introduction2Algorithms.GeometryAlgorithms
{
    public class SimplePolygon
    {
        private GeometryPoint[] geometrypoints;

        public GeometryPoint[] GeometryPoints
        {
            get { return geometrypoints; }
            set { geometrypoints = value; }
        }


        public SimplePolygon()
        {
        }
        public void Initialize(int size, double minX, double maxX, double minY, double maxY)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException();
            geometrypoints = new GeometryPoint[size];
            Random rnd = new Random(DateTime.Now.Millisecond);
            double xRange = maxX - minX;
            double yRange = maxY - minY;
            int MaxXPointIndex = 0;//选取x坐标最大的点
            for (int i = 0; i < size; i++)
            {
                GeometryPoint gp = new GeometryPoint(minX + xRange * rnd.NextDouble(), minY + yRange * rnd.NextDouble());
                geometrypoints[i] = gp;
                if (geometrypoints[MaxXPointIndex].X < gp.X)////选取x坐标最大的点
                {
                    MaxXPointIndex = i;
                }
                else if (geometrypoints[MaxXPointIndex].X < gp.X && geometrypoints[MaxXPointIndex].Y > gp.Y)//选取x坐标最大的点，如果最大x坐标点有多个，去y最小者
                {
                    MaxXPointIndex = i;
                }
            }
            //计算斜率
            for (int i = 0; i < size; i++)
            {
                if (i == MaxXPointIndex)
                {
                    geometrypoints[MaxXPointIndex].SLOPE = double.MaxValue;
                }
                else
                {
                    if (geometrypoints[i].X == geometrypoints[MaxXPointIndex].X)//与最大x坐标的x相同的点,因为x坐标之差为零，所以取SLOPE最大值
                    {
                        geometrypoints[i].SLOPE = double.MaxValue;
                    }
                    else//计算斜率，注意正切函数在-0.5Pi和0.5Pi之间是单调递增的
                    {
                        geometrypoints[i].SLOPE = (geometrypoints[i].Y - geometrypoints[MaxXPointIndex].Y) / (geometrypoints[MaxXPointIndex].X - geometrypoints[i].X);
                    }
                }
            }
            //按照斜率slope排序，取稳定排序方法的堆排序。
            HeapSort<GeometryPoint> heapsort = new HeapSort<GeometryPoint>();
            heapsort.Sort(this.geometrypoints,0,size-1);
        }
    }
}
