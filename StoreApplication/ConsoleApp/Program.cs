using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApplication.ClassLibrary.StoreApplication.Design;
using StoreApplication.DBClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Serialization;

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

            


        }

        static string getConnectionString()
        {
            string path = "../../../DBConnectionString.json";
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

        public static int chooseInput()
        {
            int input = 0;
            Console.WriteLine("Choose {0} to quit \n {1} to add a new customer\n and {2} to create a new order!");

            input = int.Parse(Console.ReadLine());
            return input;
        }

       

    }
}
 
