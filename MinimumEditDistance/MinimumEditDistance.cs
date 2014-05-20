using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.MinimumEditDistance
{
    public sealed class MinimumEditDistance
    {
        public int[,] CalculateDistance(string originalStr, String targetStr)
        {
            int LenA = originalStr.Length;
            int LenB = targetStr.Length;
            int[,] C = new int[LenA + 1, LenB + 1];
            for (int i = 0; i <= LenA; C[i, 0] = i, i++) ;//targetStr为空串时的边界条件
            for (int j = 0; j <= LenB; C[0, j] = j, j++) ;//originalStr为空串时的边界条件
            for (int i = 1; i <= LenA; i++)
            {
                for (int j = 1; j <= LenB; j++)
                {
                    //删除：考虑C[i-1，j]，即i-1时已经达到最好情况，新添加的第i个字符需要删除掉
                    int candidateDel = C[i - 1, j] + 1;
                    //插入：考虑C[i，j-1]，即已经在i的情况下能够达到j-1时的最好情况，此时如果考虑j的情况就是直接插入第j个字符
                    int candidateIns = C[i, j - 1] + 1;
                    //匹配：考虑C[i-1，j-1]，即在i-1,j-1的情况下已经得到最好值，并且新近考虑的i和j字符相同，则无需任何额外动作
                    // int candidate = C[i-1, j-1];
                    //替换：考虑C[i-1，j-1]，即在i-1,j-1的情况下已经得到最好值，并且新近考虑的i和j字符不相同，则需一次替换额外动作
                    //int candidate = C[i - 1, j - 1]+1;
                    int candidateMatRep;
                    if (char.Equals(originalStr[i - 1], targetStr[j - 1]))
                    {
                        candidateMatRep = C[i - 1, j - 1];
                    }
                    else
                    {
                        candidateMatRep = C[i - 1, j - 1] + 1;
                    }
                    //三者取最小代价
                    C[i, j] = Math.Min(Math.Min(candidateDel, candidateIns), candidateMatRep);
                }
            }
            return C;
        }
        public List<OperationOnOriginalStr> GetPossibleDesicion(int[,] C, int row, int col)
        {
            List<OperationOnOriginalStr> lo = new List<OperationOnOriginalStr>();

            for (int i = row, j = col; i > 0 || j > 0; )
            {
                if (C[i, j] == C[i - 1, j] + 1)//删除
                {
                    lo.Add(new OperationOnOriginalStr(Operation.Delete, i-1));
                    i--;
                }
                else if (C[i, j] == C[i, j - 1] + 1) //插入
                {
                    lo.Add(new OperationOnOriginalStr(Operation.Insert, i-1, j-1));
                    j--;
                }
                else if (C[i, j] == C[i - 1, j - 1])//匹配
                {
                    lo.Add(new OperationOnOriginalStr(Operation.Match, i-1,j-1));
                    i--;
                    j--;
                }
                else //替换
                {
                    lo.Add(new OperationOnOriginalStr(Operation.Replace, i-1, j-1));
                    i--;
                    j--;
                }
            }

            return lo.Reverse<OperationOnOriginalStr>().ToList<OperationOnOriginalStr>();
        }
    }
    public enum Operation
    {
        Delete,
        Insert,
        Replace,
        Match
    }
    public class OperationOnOriginalStr
    {
        public OperationOnOriginalStr(Operation op, int aindex, int? bindex = null)
        {
            operation = op;
            AIndex = aindex;
            BIndex = bindex;
        }
        public Operation operation { get; set; }
        public int AIndex { get; set; }
        public int? BIndex { get; set; }
    }
}
