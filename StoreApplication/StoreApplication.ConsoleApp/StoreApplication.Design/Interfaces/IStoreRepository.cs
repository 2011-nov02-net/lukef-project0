using System.Collections.Generic;
using StoreApplication.ClassLibrary.StoreApplication.Design;

namespace StoreApplication.DBClassLibrary.Repositories
{
    public interface IStoreRepository
    {
        List<Location> GetLocations();
        List<Customer> GetCustomers();
        List<Order> GetOrders();
        Location GetLocationByName(string name);
        Product GetProductByName(string name);
        List<Product> GetProducts();
        Customer GetCustomerByName(string FirstName, string LastName);
        void InsertCustomer(Customer customer);
        void InsertOrder(Order order);
        Order GetOrderById(int id);
        void UpdateLocationInventory(Location location, Product product);
        List<Order> GetCustomerOrders(int customerId);
        List<Order> GetLocationOrders(int locationId);
    }
}
