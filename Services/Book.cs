using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Services
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string BookNo { get; set; }
        [DataMember]
        public string BookName { get; set; }
        [DataMember]
        public Decimal BookPrice { get; set; }
    }
}
