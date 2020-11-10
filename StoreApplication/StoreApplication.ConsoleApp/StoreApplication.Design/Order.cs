using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Order
    {
        public Location location { get; set; }

        public Customer customer { get; set; }

        public DateTime OrderTime { get; set; }

        public Order(Location loc, Customer cust, DateTime dateTime)
        {
            location = loc;
            customer = cust;
            OrderTime = dateTime;
        }
    }
}
