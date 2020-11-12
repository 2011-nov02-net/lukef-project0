using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public interface IApp
    {
        void AddCustomer(Customer customer);

        void AddOrder(Order order);


        void PrintStoreOrderHistory();

        void SearchCustomerByName();


    }
}
