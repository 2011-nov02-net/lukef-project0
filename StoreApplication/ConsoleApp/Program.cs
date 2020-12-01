using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApplication.DBClassLibrary;
using StoreApplication.DBClassLibrary.Repositories;
using System;
//using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//using StoreApplication.ClassLibrary.StoreApplication.Design;

namespace ConsoleApp
{
    class Program
    {
        static DbContextOptions<Project0DBContext> s_dbContextOptions;
        public IStoreRepository Store { get; }

        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("proj0-logs.txt");

            var optionsBuilder = new DbContextOptionsBuilder<Project0DBContext>();
            optionsBuilder.UseSqlServer(getConnectionString());
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);

            s_dbContextOptions = optionsBuilder.Options;

            IStoreRepository storeRepository = new StoreRepository(s_dbContextOptions);


            Console.WriteLine("Welcome to my Store application!");

            int UserInput = chooseInput();

            while (UserInput != 0)
            {
                switch (UserInput)
                {
                    ///<summary>
                    /// Case 1: Adds a new Customer record to the Customer table
                    /// </summary>
                    case 1:
                        Console.Clear();

                        Console.WriteLine("Let's add a new customer!");

                        string firstName = "";
                        string lastName = "";
                        string Email = "";

                          

                        Console.WriteLine("Enter a first name: ");
                        firstName = Console.ReadLine();

                        Console.WriteLine("Enter a last name: ");
                        lastName = Console.ReadLine();

                        Console.WriteLine("Enter a valid email");
                        Email = Console.ReadLine();
                        

                        var newCustomer = new StoreApplication.ClassLibrary.StoreApplication.Design.Customer(firstName, lastName, Email);
                        storeRepository.InsertCustomer(newCustomer);

                        Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} was added!");

                        break;

                    ///<summary>
                    /// Case 2: Adds a new Order record to the Order table
                    /// Recieves LocationId, CustomerId, ProductId, and Quantity
                    /// </summary>
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Let's create a new order!");

                        int locationId = -1;
                        
                        Console.WriteLine("Please pick which location you'd like to order from? Enter the ID: ");
                        foreach(var loc in storeRepository.GetLocations())
                        {
                            Console.WriteLine($"{loc.LocationId} - {loc.Name}");
                        }
      
                        locationId = int.Parse(Console.ReadLine());

                        int customerId = -1;

                        Console.WriteLine("Who is ordering from this store? Enter the ID: ");

                        foreach (var cust in storeRepository.GetCustomers())
                        {
                            Console.WriteLine($"{cust.CustomerId} - {cust.FirstName} {cust.LastName}");
                        }

                        customerId = int.Parse(Console.ReadLine());

                        int productId = -1;

                        Console.WriteLine("Which product would you like to buy? Enter the ID:");                        
                            
                        foreach (var prod in storeRepository.GetProducts())
                        {
                            Console.WriteLine($"{prod.ProductId} - {prod.Title}");
                        }
                        productId = int.Parse(Console.ReadLine());
                        
                        int quantity = 0;

                        Console.WriteLine("How many would you like to buy?");

                        quantity = int.Parse(Console.ReadLine());


                        var newOrder = new StoreApplication.ClassLibrary.StoreApplication.Design.Order(locationId, customerId, productId, quantity);

                        storeRepository.InsertOrder(newOrder);

                        break;

                    ///<summary>
                    /// Case 3: Gets all orders based off of a CustomerId input
                    /// </summary>
                    case 3:
                        Console.Clear();

                        Console.WriteLine("Let's get all of a customer's orders!");
                        int custId;

                        Console.WriteLine("Which customer's orders would you like to see? Enter the ID");


                        

                        foreach(var cust in storeRepository.GetCustomers())
                        {
                            Console.WriteLine($"{cust.CustomerId} - {cust.FirstName} {cust.LastName}");
                        }
                        custId = int.Parse(Console.ReadLine());
                        

                        var orders = storeRepository.GetCustomerOrders(custId);


                        foreach (var order in orders)
                        {
                            Console.WriteLine($"ID: {order.OrderId} | Customer ID: {order.CustomerId} | Location ID: {order.LocationId} | Product ID: {order.ProductId} | Quantity: {order.Quantity}");
                        }

                        break;

                    ///<summary>
                    /// Case 4: Gets all orders based off of a LocationId input
                    /// </summary>
                    case 4:
                        Console.Clear();

                        Console.WriteLine("Let's get all of a location's orders!");
                        int locId;

                        Console.WriteLine("Which location's orders would you like to see? Enter the ID");




                        foreach (var loc in storeRepository.GetLocations())
                        {
                            Console.WriteLine($"{loc.LocationId} - {loc.Name}");
                        }
                        locId = int.Parse(Console.ReadLine());


                        var locationOrders = storeRepository.GetLocationOrders(locId);


                        foreach (var order in locationOrders)
                        {
                            Console.WriteLine($"ID: {order.OrderId} | Customer ID: {order.CustomerId} | Location ID: {order.LocationId} | Product ID: {order.ProductId} | Quantity: {order.Quantity}");
                        }

                        break;

                    case 5:
                        Console.Clear();

                        Console.WriteLine("Let's search for a customer!");

                        string FirstName = "";
                        string LastName = "";

                        Console.WriteLine("Enter a first name:");

                        FirstName = Console.ReadLine();

                        Console.WriteLine("Enter a last name:");

                        LastName = Console.ReadLine();

                        try
                        {
                            var customer = storeRepository.GetCustomerByName(FirstName, LastName);
                            Console.WriteLine($"Customer ID: {customer.CustomerId} | First Name: {customer.FirstName} | Last Name: {customer.LastName} | Email: {customer.Email}" );
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Sorry! There is no customer with that name!");
                        }

                        break;


                }

                UserInput = chooseInput();

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

            /// <summary>
            /// Receives input from the user to perform an action in the console app
            /// </summary>

            static int chooseInput()
            {
                int input = 0;
                Console.WriteLine("Choose {0} to quit");
                Console.WriteLine("Choose {1} to add a new customer");
                Console.WriteLine("Choose {2} to create an order");
                Console.WriteLine("Choose {3} to search for customer orders");
                Console.WriteLine("Choose {4} to search for location orders");
                Console.WriteLine("Choose {5} to search for a customer by name");
                try
                {
                    input = int.Parse(Console.ReadLine());
                } catch(FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("That is an incorrect command! Please try again.");
                    
                    return chooseInput();
                }
                
                return input;
            }




        }
    }
}
 
