using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreApplication.ClassLibrary.StoreApplication.Design;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StoreApplication.DBClassLibrary.Repositories
{
    public class StoreRepository : IStoreRepository
    {

        private readonly DbContextOptions<Project0DBContext> _contextOptions;

        public StoreRepository(DbContextOptions<Project0DBContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }


        public List<ClassLibrary.StoreApplication.Design.Location> GetLocations()
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbLocations = context.Locations.ToList();

            var appLocations = dbLocations.Select(l => new ClassLibrary.StoreApplication.Design.Location()
            {
                LocationId = l.LocationId,
                Name = l.Name
            }).ToList();


            return appLocations;
        }

        public List<ClassLibrary.StoreApplication.Design.Product> GetProducts()
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbProducts = context.Products.ToList();

            var appProducts = dbProducts.Select(p => new ClassLibrary.StoreApplication.Design.Product()
            {
                ProductId = p.ProductId,
                Title = p.Name,
                Price = p.Price
            }).ToList();

            return appProducts;
        }

        public List<ClassLibrary.StoreApplication.Design.Customer> GetCustomers()
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbCustomers = context.Customers.ToList();

            var appCustomers = dbCustomers.Select(c => new ClassLibrary.StoreApplication.Design.Customer()
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            }).ToList();

            //Console.WriteLine(JsonConvert.SerializeObject(appCustomers));
            
            
            return appCustomers;
        }

        public List<ClassLibrary.StoreApplication.Design.Order> GetOrders()
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbOrders = context.Orders.ToList();

            var appOrders = dbOrders.Select(o => new ClassLibrary.StoreApplication.Design.Order()
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                LocationId = o.LocationId,
                Quantity = o.Quantity
            }
            ).ToList();

            return appOrders;
        }

        public ClassLibrary.StoreApplication.Design.Customer GetCustomerByName(string firstName, string lastName)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbCustomers = context.Customers.ToList();

            var appCustomers = dbCustomers.Select(c => new ClassLibrary.StoreApplication.Design.Customer()
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            }).Where(c => c.FirstName == firstName && c.LastName == lastName).First();
            Console.WriteLine(JsonConvert.SerializeObject(appCustomers));
            return appCustomers;
        }

        public ClassLibrary.StoreApplication.Design.Location GetLocationByName(string name)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbLocations = context.Locations.ToList();

            var appLocations = dbLocations.Select(l => new ClassLibrary.StoreApplication.Design.Location()
            {
                LocationId = l.LocationId,
                Name = l.Name
            }).Where(l => l.Name == name).First();

            return appLocations;
        }

        public ClassLibrary.StoreApplication.Design.Product GetProductByName(string name)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbProducts = context.Products.ToList();

            var appProducts = dbProducts.Select(p => new ClassLibrary.StoreApplication.Design.Product()
            {
                ProductId = p.ProductId,
                Title = p.Name,
                Price = p.Price
            }
            ).Where(p => p.Title == name).First();

            return appProducts;
        }

        public ClassLibrary.StoreApplication.Design.Order GetOrderById(int id)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbOrders = context.Orders
                .Include(o => o.Location)
                .Include(o => o.Customer)
                .Include(o => o.Product)
                .First(o => o.OrderId == id);

            var location = new ClassLibrary.StoreApplication.Design.Location(dbOrders.LocationId, dbOrders.Location.Name)
            {
                LocationId = dbOrders.LocationId,
                Name = dbOrders.Location.Name,

            };

            var customer = new ClassLibrary.StoreApplication.Design.Customer()
            {
                CustomerId = dbOrders.CustomerId,
                FirstName = dbOrders.Customer.FirstName,
                LastName = dbOrders.Customer.LastName,
                Email = dbOrders.Customer.Email
            };

            var product = new ClassLibrary.StoreApplication.Design.Product()
            {
                ProductId = dbOrders.ProductId,
                Title = dbOrders.Product.Name,
                Price = dbOrders.Product.Price,
            };

            ClassLibrary.StoreApplication.Design.Order testorder = new ClassLibrary.StoreApplication.Design.Order()
            {
                OrderId = dbOrders.OrderId,
                CustomerId = customer.CustomerId,
                LocationId = location.LocationId,
                ProductId = product.ProductId,
                OrderTime = dbOrders.OrderTime,
                Quantity = dbOrders.Quantity
            };


            return testorder;


        }

        public List<ClassLibrary.StoreApplication.Design.Order> GetCustomerOrders(int customerId)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbCustomerOrders = context.Orders.Where(o => o.CustomerId == customerId).ToList();

            var appCustomerOrders = dbCustomerOrders.Select(o => new ClassLibrary.StoreApplication.Design.Order()
            {
                LocationId = o.LocationId,
                Quantity = o.Quantity
            }
            ).ToList();
            Console.WriteLine(JsonConvert.SerializeObject(appCustomerOrders));

            return appCustomerOrders;
        }

        public List<ClassLibrary.StoreApplication.Design.Order> GetLocationOrders(int locationId)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbCustomerOrders = context.Orders.Where(o => o.LocationId == locationId).ToList();

            var appLocationOrders = dbCustomerOrders.Select(co => new ClassLibrary.StoreApplication.Design.Order()
            {
                LocationId = co.LocationId,
                Quantity = co.Quantity,
            }
            ).ToList();

            Console.WriteLine(JsonConvert.SerializeObject(appLocationOrders));
            return appLocationOrders;
        }

        public void InsertCustomer(ClassLibrary.StoreApplication.Design.Customer customer)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };

            context.Customers.Add(dbCustomer);

            context.SaveChanges();
        }

        public void InsertOrder(ClassLibrary.StoreApplication.Design.Order order)
        {
            using var context = new Project0DBContext(_contextOptions);

            var dbOrder = new Order()
            {
                LocationId = order.LocationId,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity

            };

            context.Orders.Add(dbOrder);

            context.SaveChanges();
        }

        public void UpdateLocationInventory(ClassLibrary.StoreApplication.Design.Location location, ClassLibrary.StoreApplication.Design.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
