using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApplication.DBClassLibrary;
using StoreApplication.DBClassLibrary.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("proj0-logs.txt");

            var optionsBuilder = new DbContextOptionsBuilder<Project0DBContext>();
            optionsBuilder.UseSqlServer(getConnectionString());
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);

            using var context = new Project0DBContext(optionsBuilder.Options);

            //IApp app = new Application();
            IStoreRepository storeRepository = new StoreRepository(context);

            

            //Display5Customers();
            Console.WriteLine();

            //UpdateCustomer();
            //Display5Customers();
            Console.WriteLine();

            //InsertCustomer();
            //Display5Customers();

            Console.WriteLine();
            //DeleteCustomer();
            //Display5Customers();



        }

        static string getConnectionString()
        {
            string path = "../../../../../../DBConnectionString.json";
            string json;

            try
            {
                json = File.ReadAllText(path);
            }
            catch (IOException)
            {
                Console.WriteLine("Path is not available");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;
        }

        //static void Display5Customers()
        //{
        //    using var context = new Project0DBContext(s_dbContextOptions);

        //    IQueryable<StoreApplication.DBClassLibrary.Customer> customers = context.Customers
        //        .OrderBy(c => c.FirstName)
        //        .Take(5);

        //    foreach (StoreApplication.DBClassLibrary.Customer customer in customers)
        //    {
        //        Console.WriteLine($"{customer.CustomerId} - {customer.FirstName} {customer.LastName}");
        //    }
                
        //}

        //static void UpdateCustomer()
        //{
        //    using var context = new Project0DBContext(s_dbContextOptions);

        //    StoreApplication.DBClassLibrary.Customer customer = context.Customers.OrderBy(x => x.FirstName).First();

        //    customer.FirstName += ".";

        //    context.SaveChanges();
        //}

        //static void InsertCustomer()
        //{
        //    using var context = new Project0DBContext(s_dbContextOptions);

        //    var firstCustomer = context.Customers.OrderBy(c => c.FirstName).First();
        //    string nameOfFirstCustomer = firstCustomer.FirstName;

        //    var customer = new StoreApplication.DBClassLibrary.Customer()
        //    {
        //        FirstName = "Dave",
        //        LastName = "Fisher",
        //        Email = "dfisher@email.com"
        //    };

        //    context.Customers.Add(customer);

        //    context.SaveChanges();

        //}

        //static void DeleteCustomer()
        //{
        //    using var context = new Project0DBContext(s_dbContextOptions);

        //    var customer = context.Customers.Where(t => t.FirstName == "Dave").First();
        //    context.Customers.Remove(customer);

        //    context.SaveChanges();
        //}

       

    }
}
 
