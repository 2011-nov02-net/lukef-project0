using System;
using System.Collections.Generic;
using System.Text;
using StoreApplication.ClassLibrary.StoreApplication.Design;

namespace StoreApplication.DBClassLibrary.Repositories
{
    public interface IStoreRepository
    {
        ICollection<Customer> GetCustomerByName(string firstName, string lastName);
        void InsertCustomer(Customer customer);
        void InsertOrder(Order order);
        void UpdateLocationInventory(Location location, Product product);
        List<Order> GetCustomerOrders(Customer customer);
        List<Order> GetLocationOrders(Location location);
    }
}
