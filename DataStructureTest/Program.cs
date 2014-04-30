using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introduction2Algorithms.DataStructure;

namespace Introduction2Algorithms.DataStructureTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            MaxPriorityQueue<IHeapValue> maxheap = new MaxPriorityQueue<IHeapValue>();
            MinPriorityQueue<IHeapValue> minheap = new MinPriorityQueue<IHeapValue>();
            List<IHeapValue> list = new List<IHeapValue>();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
            {
                HeapNode hn = new HeapNode() { Value = rnd.Next(0, 100) };
                list.Add(hn);
                maxheap.Insert(hn);
                minheap.Insert(hn);
            }
            Console.WriteLine("RandomData:");
            list.ForEach(n => Console.Write("{0},", n.Value));
            Console.WriteLine(Environment.NewLine + "MaxHeapOutput:");
            while (!maxheap.IsEmpty)
            {
                Console.Write("{0},", maxheap.ExtractMax().Value);
            }
            Console.WriteLine(Environment.NewLine + "MinHeapOutput:");
            while (!minheap.IsEmpty)
            {
                Console.Write("{0},", minheap.ExtractMin().Value);
            }
            Console.ReadKey();

        }
    }
}
