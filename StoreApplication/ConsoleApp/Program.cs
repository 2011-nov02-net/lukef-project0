using StoreApplication.ClassLibrary.StoreApplication.Design;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp app = new Application();

            try
            {
                app.AddOrder(new Order(
                    new Location("West Street"),
                    new Customer("Jerry"),
                    new List<Product>
                    {
                        new Product("lollipop", 1.00, 50),
                        new Product("cupcake", 3.00, 3),
                        new Product("muffin", 5.00, 1)
                    }
                    ));

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


            //Console.WriteLine("Welcome to my Store application! You must fill you inventory first");
            //int UserInput = chooseInput();

            //while (UserInput != 0)
            //{
            //    switch (UserInput)
            //    {
            //        case 1:


            //            Console.WriteLine("Let's add some inventory to a store!");

            //            int LocationId = 0;

            //            Console.WriteLine("Which store are you adding to? [Please type its ID number]");
            //            printLocationList();
            //            LocationId = int.Parse(Console.ReadLine());

            //            string Title = "";

            //            Console.WriteLine("What is your product?");
            //            Title = Console.ReadLine();

            //            double Price = 0;

            //            Console.WriteLine("What is the price of the product?");
            //            Price = double.Parse(Console.ReadLine());

            //            int Quantity = 0;

            //            Console.WriteLine("How many of of this product are you adding?");
            //            Quantity = int.Parse(Console.ReadLine());

            //            Product prod = new Product(Title, Price, Quantity);

            //            Location.ProductList.Add(prod);

            //            printProductList();
            //            break;

            //        case 2:

            //            Console.WriteLine("Let's add a customer!");

            //            int CustomerID = 0;

            //            string CustomerName = "";


            //            Console.WriteLine("What is the customer's name?");
            //            CustomerName = Console.ReadLine();

            //            Console.WriteLine("Where store will they be shopping at?");


            //            Customer cust = new Customer(CustomerName, CustomerID);














            //}
            //UserInput = chooseInput();
            //}           


        }


        //private static void printLocationList()
        //{
        //    foreach (Location l in AllStores.LocationList)
        //    {
        //        Console.WriteLine("Location Name: " + Location.LocationName + "Location ID: " + Location.LocationId);
        //    }
        //}

        //private static void printProductList()
        //{ 
        //    foreach (Product p in Location.ProductList)
        //    {
        //        Console.WriteLine("Product Name: " + Product.Title + "\n");
        //    }
        //}

        

        //static public int chooseInput()
        //{
        //    int input = 0;
        //    Console.WriteLine("Choose {0} to quit, {1} to add inventory to a store, {2} to add a new customer, and {3} to create a new order!");

        //    input = int.Parse(Console.ReadLine());
        //    return input;
        //}
    }
}
