using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Week4_EsFinale_Dal_Savio.Core
{
    [DataContract]
    public class Customer
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

        //Aggiungere attributi DataContract e DataMember

    }
}
