using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.DBClassLibrary.Repositories
{
    class StoreRepository : IStoreRepository
    {
        
        private readonly Project0DBContext _contextOptions;

        public StoreRepository(Project0DBContext contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = _contextOptions.Customers.Find(customerId);
            _contextOptions.Customers.Remove(customer);
            _contextOptions.SaveChanges();
        }

        public void DeleteLocation(int locationId)
        {
            Location location = _contextOptions.Locations.Find(locationId);
            _contextOptions.Locations.Remove(location);
            _contextOptions.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            Order order = _contextOptions.Orders.Find(orderId);
            _contextOptions.Orders.Remove(order);
            _contextOptions.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            Product product = _contextOptions.Products.Find(productId);
            _contextOptions.Products.Remove(product);
            _contextOptions.SaveChanges();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _contextOptions.Customers.Find(customerId);
        }

        public IEnumerable<Order> GetCustomerOrders(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _contextOptions.Customers.ToList();
        }

        public Location GetLocationById(int locationId)
        {
            return _contextOptions.Locations.Find(locationId);
        }

        public IEnumerable<Order> GetLocationOrders(Location location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocations()
        {
            return _contextOptions.Locations.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _contextOptions.Orders.Find(orderId);            
        }

        public IEnumerable<Order> GetOrders()
        {
            return _contextOptions.Orders.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _contextOptions.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _contextOptions.Products.ToList();
        }

        public int InsertCustomer(Customer customer)
        {
            int result = -1;

            if(customer != null)
            {
                _contextOptions.Customers.Add(customer);
                _contextOptions.SaveChanges();
                result = customer.CustomerId;
            }
            return result;
        }

        public int InsertLocation(Location location)
        {
            int result = -1;

            if(location != null)
            {
                _contextOptions.Locations.Add(location);
                _contextOptions.SaveChanges();
                result = location.LocationId;
            }
            return result;
        }

        public int InsertOrder(Order order)
        {
            int result = -1;

            if(order != null)
            {
                _contextOptions.Orders.Add(order);
                _contextOptions.SaveChanges();
                result = order.LocationId;
            }
            return result;
        }

        public int InsertProduct(Product product)
        {
            int result = -1;

            if(product != null)
            {
                _contextOptions.Products.Add(product);
                _contextOptions.SaveChanges();
                result = product.ProductId;
            }
            return result;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = -1;

            if (customer != null)
            {
                _contextOptions.Entry(customer).State = EntityState.Modified;
                _contextOptions.SaveChanges();
                result = customer.CustomerId;
            }
            return result;
        }

        public int UpdateInventory(Location location, Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public int UpdateLocation(Location location)
        {
            int result = -1;

            if (location != null)
            {
                _contextOptions.Entry(location).State = EntityState.Modified;
                _contextOptions.SaveChanges();
                result = location.LocationId;
            }
            return result;
        }

        public int UpdateOrder(Order order)
        {
            int result = -1;

            if (order != null)
            {
                _contextOptions.Entry(order).State = EntityState.Modified;
                _contextOptions.SaveChanges();
                result = order.OrderId;
            }
            return result;
        }

        public int UpdateProduct(Product product)
        {
            int result = -1;

            if (product != null)
            {
                _contextOptions.Entry(product).State = EntityState.Modified;
                _contextOptions.SaveChanges();
                result = product.ProductId;
            }
            return result;
        }
    }
}
