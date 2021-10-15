using System;
using System.Collections.Generic;
using System.Text;

namespace Week4_EsFinale_Dal_Savio.Core
{
    public class MainBL : IMainBL
    {
        private readonly IOrderRepository orderRepo;
        private readonly ICustomerRepository customerRepo;

        public MainBL(IOrderRepository orderRepo, ICustomerRepository customerRepo
        )
        {
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        #region Customers
        //Metodi per i clienti 
        public List<Customer> FetchCustomers()
        {
            throw new NotImplementedException();
        }

        public bool CreateCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(Customer customerToBeDeleted)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Orders
        //Metodi per gli ordini
        public bool CreateOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(Order orderToBeDeleted)
        {
            throw new NotImplementedException();
        }
        public bool EditOrder(Order editedOrder)
        {
            throw new NotImplementedException();
        }

        public List<Order> FetchOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
