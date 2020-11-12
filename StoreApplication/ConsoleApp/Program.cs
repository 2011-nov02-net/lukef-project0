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
                        Console.Clear();
                        Console.WriteLine("Let's add a customer!");

                        string FirstName = "";
                        string LastName = "";


                        Console.WriteLine("What is the customer's first name?");
                        FirstName = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What is the customer's last name?");
                        LastName = Console.ReadLine();                       

                        app.AddCustomer(new Customer(FirstName, LastName));
                        Console.Clear();

                        Console.WriteLine("{0} {1} was added to Customers!", FirstName, LastName);

                        break;

                }
                UserInput = chooseInput();
            }


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
 
