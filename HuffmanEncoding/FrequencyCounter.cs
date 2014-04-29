using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.HuffmanEncoding
{
    public class FrequencyCounter
    {
        public CharFreqKvp[] MapReduce(string str)
        {
            //the GroupBy method is acting as the map, 
            //while the Select method does the job of reducing the intermediate results into the final list of results.
            var wordOccurrences = str
                .GroupBy(w => w)
                .Select(intermediate => new CharFreqKvp()
                    {
                        Key = intermediate.Key,
                        Freq = intermediate.Sum(w => 1)
                    })
                .OrderBy(kvp => kvp.Freq);
            return wordOccurrences.ToArray<CharFreqKvp>();
        }
    }
    public struct CharFreqKvp
    {
        public char Key;
        public int Freq;
    }
}
