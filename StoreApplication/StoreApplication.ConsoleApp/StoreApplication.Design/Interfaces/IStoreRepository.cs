using System;
using System.Collections.Generic;
using System.Text;
using StoreApplication.ClassLibrary.StoreApplication.Design;

namespace StoreApplication.DBClassLibrary.Repositories
{
    public interface IStoreRepository
    {
        List<Location> GetLocations();
        List<Customer> GetCustomers();
        Location GetLocationByName(string name);
        List<Product> GetProducts();
        Customer GetCustomerByName(string FirstName, string LastName);
        void InsertCustomer(Customer customer);
        void InsertOrder(Order order);
        Order GetOrderById(int id);
        void UpdateLocationInventory(Location location, Product product);
        List<Order> GetCustomerOrders(Customer customer);
        List<Order> GetLocationOrders(Location location);
    }
}
