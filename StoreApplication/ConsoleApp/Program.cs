using StoreApplication.ClassLibrary.StoreApplication.Design;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AllStores storeList = new AllStores();
            Location walmart = new Location("Walmart", 0);
            AllStores.LocationList.Add(walmart);
            Location mcdonalds = new Location("Mcdonalds", 1);
            AllStores.LocationList.Add(mcdonalds);
            Location giant = new Location("Giant", 2);
            AllStores.LocationList.Add(giant);

            Console.WriteLine("Welcome to my Store application! You must fill you inventory first");
            int UserInput = chooseInput();

            while (UserInput != 0)
            {
                switch (UserInput)
                {
                    case 1:


                        Console.WriteLine("Let's add some inventory to a store!");

                        int LocationId = 0;

                        Console.WriteLine("Which store are you adding to? [Please type its ID number]");
                        printLocationList();
                        LocationId = int.Parse(Console.ReadLine());

                        string Title = "";

                        Console.WriteLine("What is your product?");
                        Title = Console.ReadLine();

                        double Price = 0;

                        Console.WriteLine("What is the price of the product?");
                        Price = double.Parse(Console.ReadLine());

                        int Quantity = 0;

                        Console.WriteLine("How many of of this product are you adding?");
                        Quantity = int.Parse(Console.ReadLine());

                        Product prod = new Product(Title, Price, Quantity);

                        Location.ProductList.Add(prod);

                        printProductList();
                        break;
                        



                }
                UserInput = chooseInput();
            }           


        }


        private static void printLocationList()
        {
            foreach (Location l in AllStores.LocationList)
            {
                Console.WriteLine("Location Name: " + Location.LocationName + "Location ID: " + Location.LocationId);
            }
        }

        private static void printProductList()
        { 
            foreach (Product p in Location.ProductList)
            {
                Console.WriteLine("Product Name: " + Product.Title + "\n");
            }
        }

        

        static public int chooseInput()
        {
            int input = 0;
            Console.WriteLine("Choose {0} to quit, {1} to add inventory to a store, {2} to add a new customer, and {3} to create a new order!");

            input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}
