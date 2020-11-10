using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Location
    {

        public static List<Product> ProductList { get; set; }

        public static List<Customer> CustomerList { get; set; }

        public static List<Order> OrderList { get; set; }

        public static string LocationName { get; set; }

        public static int LocationId { get; set; }

        public Location(string locationName, int locationId)
        {
            LocationId = locationId;
            LocationName = locationName;
            ProductList = new List<Product>();
            CustomerList = new List<Customer>();
            OrderList = new List<Order>();
        }

        

        

    }
}
