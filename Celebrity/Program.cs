using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Celebrity
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the total peoples count:");
            var countObj = Console.ReadLine(); 
            int size = int.Parse(countObj.ToString());
            Console.Write("Enter the celebrity index you want to put:");
            var celebrityIndexObj = Console.ReadLine();
            int celebrityIndex = int.Parse(celebrityIndexObj.ToString());

            int[,] knowArray = CelebrityUtility.initCelebrityData(size, celebrityIndex);
            int Index=-1;
            bool IsCelebrityExist = CelebrityUtility.FindCelebrity(knowArray, ref Index);
            if (IsCelebrityExist)
            {
                Console.WriteLine("Find the celebrate at index {0}", Index);
            }
            else
            {
                Console.WriteLine("Can Not find the celebrate");
            }
            Console.ReadKey();
        }      
    }
}
