using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Location
    {

        public int LocationId { get; set; }
        public string Name { get; set; }
         

        public Dictionary<Product, int> Quantity { get; set; }
        public Dictionary<Product, decimal> Price { get; set; }

        public Location()
        {

        }

        public Location(int locationId, string name)
        {
            LocationId = locationId;
            Name = name;
            Quantity = new Dictionary<Product, int>();
            Price = new Dictionary<Product, decimal>();
        }





    }
}
