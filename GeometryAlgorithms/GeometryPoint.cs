using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.GeometryAlgorithms
{
    public struct GeometryPoint : IComparable<GeometryPoint>
    {        
        public GeometryPoint(double x, double y, double slope = double.NaN)
        {
            this.x = x;
            this.y = y;
            this.slope = slope;
        }
        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        private double slope;
        public double SLOPE
        {
            get { return slope; }
            set { slope = value; }
        }
      
        public int CompareTo(GeometryPoint p)
        {
            if (this.slope < p.slope)
            {
                return -1;
            }
            else if (this.slope > p.slope)
            {
                return 1;
            }
            else
            {
                if (this.x == p.x && this.SLOPE == p.SLOPE && this.SLOPE == double.MaxValue)
                {
                    if (this.y == p.y)
                    {
                        return 0;
                    }
                    else if (this.y < p.y)
                    {
                        return 1;
                    }
                    else//(this.y > p.y)
                    {
                        return -1;
                    }
                }
                return 0;
            }
        }
        public override string ToString()
        {
            return string.Format("x:{0},y:{1},slope:{2}", x, y, slope);
        }
    }
}
