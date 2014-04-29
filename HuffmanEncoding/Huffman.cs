using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.HuffmanEncoding
{
    public class Huffman
    {
        private CharFreqKvp[] huffmanEncoding;
        public Huffman(CharFreqKvp[] kvps)
        {
            buildMaxHeap(kvps);
        }

        private CharFreqKvp[] buildMaxHeap(CharFreqKvp[] kvps)
        {
            //计算构成huffman堆的所有节点。
            List<CharFreqKvp> totalNodes = new List<CharFreqKvp>();
            List<CharFreqKvp> tmpNodes = new List<CharFreqKvp>(kvps);
            while (tmpNodes.Count > 0)
            {
                //CharFreqKvp cfk1 = tmpNodes.Min<CharFreqKvp>(cfk.Freq);
            }


            CharFreqKvp[] cfk = new CharFreqKvp[10];

            return cfk;
        }
    }
}
