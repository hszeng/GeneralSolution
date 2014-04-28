using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introduction2Algorithms.Outline
{
    public class Building<T> where T : IComparable<T>
    {
        public Building()
        {
        }
        public Building(T x1, T h, T x2)
        {
            Data.Add(x1);
            Data.Add(h);
            Data.Add(x2);
        }

        public T this[int i]
        {
            get
            {
                return Data[i];
            }
            set
            {
                Data[i] = value;
            }
        }

        public List<T> Data = new List<T>();
    }
}
