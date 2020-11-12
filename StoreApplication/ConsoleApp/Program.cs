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
                app.AddCustomer(new Customer("Luke", "Fisher"));

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("Welcome to my Store application! You must fill you inventory first");
            int UserInput = chooseInput();

            while (UserInput != 0)
            {
                switch (UserInput)
                {
                    case 1:

                        Console.WriteLine("Let's add a new store!");

                        string LocationName = "";

                        Console.WriteLine("What is the name if your store?");
                        LocationName = Console.ReadLine();

                        app.AddLocation(new Location(LocationName));
                        Console.WriteLine("{1} was added to Stores!", LocationName);

                        break;

                    case 2:

                        Console.WriteLine("Let's add some inventory to a store!");

                        int LocationId = 0;

                        Console.WriteLine("Which store are you adding to? [Please type its ID number]");
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
                        break;

                    case 3:

                        Console.WriteLine("Let's add a customer!");

                        string FirstName = "";
                        string LastName = "";


                        Console.WriteLine("What is the customer's first name?");
                        FirstName = Console.ReadLine();

                        Console.WriteLine("What is the customer's last name?");
                        LastName = Console.ReadLine();                       

                        app.AddCustomer(new Customer(FirstName, LastName));
                        Console.WriteLine("{1} {2} was added!", FirstName, LastName);

                        break;

                }
                UserInput = chooseInput();
            }


        }               

        public static int chooseInput()
        {
            int input = 0;
            Console.WriteLine("Choose {0} to quit \n {1} to add a new store \n {2} to add inventory to a store \n {3} to add a new customer\n and {4} to create a new order!");

            input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}
 
