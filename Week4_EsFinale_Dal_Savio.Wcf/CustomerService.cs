using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4_EsFinale_Dal_Savio.Core;
using Week4_EsFinale_Dal_Savio.EF;

namespace Week4_EsFinale_Dal_Savio.Wcf
{
    public class CustomerService : ICustomerService
    {
        //Implementazione del Service Contract 
        //-> Ci saranno metodi che chiamano metodi del business layer.

        //Vedi fetch come esempio

        private readonly MainBL mainBusinessLayer;

        public CustomerService()
        {
            mainBusinessLayer = new MainBL(
                new EFOrderRepository(),
                new EFCustomerRepository()
            );
        }

        public bool AddCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            var result = mainBusinessLayer.FetchCustomers().ToList();
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer == null)
            {
                return false;
            }
            else
            {
                return true;//mainBusinessLayer.UpdateCostumer(updatedCustomer);
            }
        }
    }
}
