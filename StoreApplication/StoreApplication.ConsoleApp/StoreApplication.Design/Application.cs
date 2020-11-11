using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Application : IApp
    {
        private List<Location> _locationlist = new List<Location>();
        public List<Location> LocationList { get => _locationlist; private set => _locationlist = value; }

        private List<Order> _orderlist = new List<Order>();
        public List<Order> OrderList { get => _orderlist; private set => _orderlist = value; }

        private List<Customer> _customerlist = new List<Customer>();
        public List<Customer> CustomerList { get => _customerlist; private set => _customerlist = value; }

        

        void IApp.AddCustomer(Customer customer)
        {
            if (!_customerlist.Contains(customer))
            {
                _customerlist.Add(customer);
            }
        }

        void IApp.AddLocation(Location location)
        {
            if (!_locationlist.Contains(location))
            {
                _locationlist.Add(location);
            }
        }

        void IApp.AddOrder(Order order)
        {
            if (!_orderlist.Contains(order))
            {
                _orderlist.Add(order);
            }
        }


    }
}
