using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.HuffmanEncoding
{
    public class FrequencyCounter
    {
        public IEnumerable<KeyValuePair<char, int>> MapReduce(string str)
        {
            //the GroupBy method is acting as the map, 
            //while the Select method does the job of reducing the intermediate results into the final list of results.
            var wordOccurrences = str
                .GroupBy(w => w)
                .Select(intermediate => new
                    {
                        Key = intermediate.Key,
                        Value = intermediate.Sum(w => 1)
                    })
                .OrderBy(kvp => kvp.Value);
            IEnumerable<KeyValuePair<char, int>> kvps = from wo in wordOccurrences select new KeyValuePair<char, int>(wo.Key, wo.Value);
            return kvps;
        }
    }

}
