using System;

namespace Week4_EsFinale_Dal_Savio.Core
{

    public class Order
    {
        //ID (int, PK), DataOrdine (date), CodiceOrdine (string), CodiceProdotto (string), Importo  (decimal), Cliente(?, FK
        public int OrderId { get; set; }
        public DateTime DataOrdine { get; set; }
        public string CodiceOrdine { get; set; }
        public string CodiceProdotto { get; set; }
        public decimal Importo { get; set; }
        public Customer Cliente { get; set; }
        public int CustomerId { get; set; }
    }
}
