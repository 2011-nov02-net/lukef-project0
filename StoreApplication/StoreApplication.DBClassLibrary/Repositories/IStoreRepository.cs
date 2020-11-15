using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.DBClassLibrary.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Product> GetProducts();
        IEnumerable<Location> GetLocations();
        IEnumerable<Order> GetOrders();
        Customer GetCustomerById(int customerId);
        Product GetProductById(int productId);
        Location GetLocationById(int locationId);
        Order GetOrderById(int orderId);
        int InsertCustomer(Customer customer);
        int InsertProduct(Product product);
        int InsertLocation(Location location);
        int InsertOrder(Order order);
        int UpdateCustomer(Customer customer);
        int UpdateProduct(Product product);
        int UpdateLocation(Location location);
        int UpdateOrder(Order order);
        void DeleteCustomer(int customerId);
        void DeleteProduct(int productId);
        void DeleteLocation(int locationId);
        void DeleteOrder(int orderId);
        int UpdateInventory(Location location, Product product, int quantity );
        IEnumerable<Order> GetCustomerOrders(Customer customer);
        IEnumerable<Order> GetLocationOrders(Location location);
    }
}
