using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.Client
{
    public class CustomerContract
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CodiceCliente { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cognome { get; set; }
        [DataMember]
        public List<Order> Orders { get; set; }
    }
}
