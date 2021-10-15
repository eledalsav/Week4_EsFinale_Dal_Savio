using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.Client
{
    public class OrderContract
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime DataOrdine { get; set; }
        [DataMember]
        public string CodiceOrdine { get; set; }
        [DataMember]
        public string CodiceProdotto { get; set; }
        [DataMember]
        public decimal Importo { get; set; }
        [DataMember]
        public Customer Cliente { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
    }
}

