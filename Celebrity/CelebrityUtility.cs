using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Celebrity
{
    /// <summary>
    /// Project:Celebrity
    /// Author: Andy Zeng 
    /// Email:andyzengsh@gmail.com 
    /// Date:2014/04/12
    /// </summary>
    class CelebrityUtility
    {
        public static int[,] initCelebrityData(int size, int celebrateIndex)
        {
            int[,] arrray = new int[size, size];
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; i++)
            {
                int tmpColumn = rnd.Next(0, size - 1);
                for (int j = 0; j < size; j++)
                {
                    if (j == tmpColumn)
                    {
                        arrray[i, j] = 1;//每一行至少有一个元素为1，每个人至少认识一个人
                    }
                    else
                    {
                        arrray[i, j] = rnd.Next(100) % 2;
                    }
                }
            }
            //构造一个名流         
            for (int i = 0; i < size; i++)
            {
                arrray[celebrateIndex, i] = 0;  //Celebrity know nobody.
                arrray[i, celebrateIndex] = 1;//Everybody knows the Celebrity.
            }
            return arrray;
        }

        public static bool FindCelebrity(int[,] knowArray, ref int celebrityIndex)
        {
            if (knowArray == null) throw new ArgumentNullException("knowArray");
            if (knowArray.GetUpperBound(0) != knowArray.GetUpperBound(1)) throw new Exception("A square matrix is required.");
            int i = 0;//candidate
            for (int j = 1; j <= knowArray.GetUpperBound(0); j++)
            {
                if (knowArray[i, j] == 1)//i know j
                    i = j;
            }
            bool result = true;

            for (int j = 0; j <= knowArray.GetUpperBound(0); j++)
            {
                if (i == j) continue;
                if (knowArray[i, j] == 1 || knowArray[j, i] == 0)//i know j
                {
                    result = false;
                    break;
                }
            }

            if (result)
            { celebrityIndex = i; }
            else
            { celebrityIndex = -1; }
            return result;
        }
    }
}
