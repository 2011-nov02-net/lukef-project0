using StoreApplication.ClassLibrary.StoreApplication.Design;
using System;
<<<<<<< HEAD
//using System.Collections.Generic;
//using System.Text;
=======
>>>>>>> 176ff78dbc1db3030f7818d64bdcd4bff191644a

namespace ConsoleApp
{
    class ConsolePrompts
    {
        public static void LocationsPrompt()
        {
            Console.WriteLine("Here are all the locations. Please select one by typing their ID number: ");
            Console.WriteLine("{1} - Walmart");
            Console.WriteLine("{2} - Giant");
            Console.WriteLine("{3} - Walgreens");
        }

        public static Location ChooseStore()
        {
            string chooseInput = Console.ReadLine();
            switch (chooseInput)
            {
                case "1":
                    return ConsoleMethods.GetLocationByName("Walmart");

                case "2":
                    return ConsoleMethods.GetLocationByName("Giant");

                case "3":
                    return ConsoleMethods.GetLocationByName("Walgreens");

                default:
                    Console.WriteLine("This is not a valid location");
                    return ChooseStore();
            }
        }

        public static void LocationServiceMenu(string input, Location location)
        {
            Console.WriteLine($"Welcome to {location.Name}! What would you like to do?");
            Console.WriteLine("{1} - Add an order");
            Console.WriteLine("{2} - View location order history");
            Console.WriteLine("{3} - View inventory");
        }

        
    }
}
