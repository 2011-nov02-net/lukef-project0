using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Product
    {

        public static string Title { get; set; }
        public static double Price { get; set; }
        public static int Quantity { get; set; }

        public int locationID { get; set; }

        public Product(string title, double price, int quantity)

        {
            locationID = Location.LocationId;
            Title = title;
            Price = price;
            Quantity = quantity;
        }

        
    }
}
