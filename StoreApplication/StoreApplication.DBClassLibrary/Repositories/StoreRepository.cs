using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreApplication.ClassLibrary.StoreApplication.Design;

namespace StoreApplication.DBClassLibrary.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        
        private readonly Project0DBContext _contextOptions;

        public StoreRepository(Project0DBContext contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public ICollection<ClassLibrary.StoreApplication.Design.Customer> GetCustomerByName(string firstName, string lastName)
        {
            var dbCustomers = _contextOptions.Customers.ToList();

            return dbCustomers.Select(c => new ClassLibrary.StoreApplication.Design.Customer()
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            }).Where(c => c.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)
                        && c.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Order> GetCustomerOrders(ClassLibrary.StoreApplication.Design.Customer customer)
        {
            var dbCustomerOrders = _contextOptions.Orders
                .Include(or => or.Customer)
                .Include(or => or.Quantity)
                .Include(or => or.Product)
                .Include(or => or.OrderTime)
                .OrderBy(or => or.OrderTime);
            List<Order> orders = new List<Order>();
            foreach(var order in dbCustomerOrders)
            {
                orders.Add(order);
            }

            return orders;
        }

        public List<ClassLibrary.StoreApplication.Design.Order> GetLocationOrders(ClassLibrary.StoreApplication.Design.Location location)
        {
            var dbLocationOrders = _contextOptions.Orders
                .Include(or => or.Location)
                .Include(or => or.Product)
                .Include(or => or.Quantity)
                .Include(or => or.OrderTime)
                .OrderBy(or => or.OrderTime);
            List<ClassLibrary.StoreApplication.Design.Order> orders = new List<ClassLibrary.StoreApplication.Design.Order>();
            foreach(var order in dbLocationOrders)
            {
                orders.Add(order);
            }

            return orders;
        }

        public void InsertCustomer(ClassLibrary.StoreApplication.Design.Customer customer)
        {
            var dbCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };

            _contextOptions.Customers.Add(dbCustomer);
        }

        public void InsertOrder(ClassLibrary.StoreApplication.Design.Order order)
        {
            var customer = _contextOptions.Customers.First(c => c.CustomerId == order.Customer.CustomerId);
            var location = _contextOptions.Locations.First(l => l.LocationId == order.Location.LocationId);

            var dbOrder = new Order()
            {
                Customer = customer,
                Location = location,
            };

            _contextOptions.Orders.Add(dbOrder);
        }

        public void UpdateLocationInventory(Location location, Product product)
        {
            //StoreInventory storeInventory;

            //storeInventory = _contextOptions.StoreInventories.First(li => li.LocationId == location.LocationId);
            //storeInventory.Quantity = Location.Quantity[product];

            //var dbProduct = _contextOptions.Products.First(pr => pr.ProductId == product.ProductId);

        }
    }
}
