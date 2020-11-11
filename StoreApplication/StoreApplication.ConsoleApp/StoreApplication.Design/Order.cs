using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Order
    {
        private Location _location1;
        private Customer _customer1;
        private DateTime _orderTime;

        public Location location { get => _location1; private set => _location1 = value; }

        public Customer customer { get => _customer1; private set => _customer1 = value; }

        public DateTime OrderTime { get => _orderTime; private set => _orderTime = value; }

        public Order(Location loc, Customer cust, DateTime dateTime)
        {
            location = loc;
            customer = cust;
            OrderTime = dateTime;
        }
    }
}
