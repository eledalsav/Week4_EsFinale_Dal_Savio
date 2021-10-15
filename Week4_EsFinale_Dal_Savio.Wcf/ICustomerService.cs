using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.Wcf
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetAllCustomers();

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        bool AddCustomer(Customer newCustomer);

        [OperationContract]
        bool UpdateCustomer(Customer updatedCustomer);

        [OperationContract]
        bool DeleteCustomerById(int id);
    }
}
