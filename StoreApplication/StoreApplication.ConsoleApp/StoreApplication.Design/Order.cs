using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Order
    {

        public int OrderId { get; set; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }
        public Dictionary<Product, int> Product { get; set; }
        public DateTime OrderTime { get ; set; }
        public int Quantity { get; set; }

        public Order()
        {

        }

        public Order(Location location , Customer customer, int quantity)
        {
            Location = location;
            Customer = customer;
            Product = customer.ShoppingCart;
            Quantity = quantity;
        }
    }
}
