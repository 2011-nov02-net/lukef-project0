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

    }
}
