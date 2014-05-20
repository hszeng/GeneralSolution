using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introduction2Algorithms.MinimumEditDistance;

namespace MinimumEditDistanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "abcxpqef";
            string B = "cxemnq";
            Console.WriteLine("A:" + A);
            Console.WriteLine("B:" + B);
            MinimumEditDistance med = new MinimumEditDistance();
            var C = med.CalculateDistance(A, B);
            var steps = med.GetPossibleDesicion(C, A.Length, B.Length);
            steps.ForEach(s => Console.WriteLine("Operation:{0},A[{1}],B[{2}]", s.operation, s.AIndex, s.BIndex));
            Console.ReadKey();
        }
    }
}
