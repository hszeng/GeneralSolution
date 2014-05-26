using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.GeometryAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplePolygon sp = new SimplePolygon();
            sp.Initialize(10, -50, 50, -50, 50);
            for (int i = 0; i < sp.GeometryPoints.Length; i++)
            {
                Console.WriteLine(sp.GeometryPoints[i]);
            }
            Console.ReadKey();
        }
    }
}
