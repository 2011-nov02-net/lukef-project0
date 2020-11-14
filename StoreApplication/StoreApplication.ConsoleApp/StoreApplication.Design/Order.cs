using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Order
    {
        private Location _location1;
        private Customer _customer1;
        private List<Product> _products = new List<Product>();

        public Location location { get => _location1; private set => _location1 = value; }
        public Customer customer { get => _customer1; private set => _customer1 = value; }
        public DateTime OrderTime { get ; private set; }
        public List<Product> Products { get => _products; private set => _products = value; }

        public Order(Location loc, Customer cust, List<Product> prod)
        {
            location = loc;
            customer = cust;
            OrderTime = DateTime.Now;
            Products = prod;

        }
    }
}
