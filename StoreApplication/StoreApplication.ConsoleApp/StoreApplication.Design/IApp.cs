using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public interface IApp
    {
        void AddCustomer(Customer customer);

        void AddLocation(Location location);

        void AddOrder(Order order);

        void AddProductLocation(Location location, List<Product> product);

        void PrintStoreOrderHistory();

        void PrintCustomerOrderHistory();

        void SearchCustomerByName();


    }
}
