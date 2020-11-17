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
                    case 1:

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

                        break;

                    case 2:

                        Console.WriteLine("Let's create a new order!");

                        Console.WriteLine("Which location would you like to place an order? [Enter the number that is next to the name]");

                        break;

                    

                }
                    



            }



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

        static public int chooseInput()
        {
            int input = 0;
            Console.WriteLine("Choose {0} to quit, {1} to add a new customer, and {2} to create an order!");

            input = int.Parse(Console.ReadLine());
            return input;
        }



    }
}
 
