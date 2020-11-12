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
            if (!_customerlist.Contains(order.customer))
            {
                throw new ArgumentException("That customer is not in our files!");
            }
            if (!_locationlist.Contains(order.location))
            {
                throw new ArgumentException("That location is not in our files!");
            }
        }

        void IApp.AddProductLocation(Location location, List<Product> product)
        { 
          
            
        }

        void IApp.PrintCustomerOrderHistory()
        {

        }

        void IApp.PrintStoreOrderHistory()
        {

        }

        void IApp.SearchCustomerByName()
        {

        }


    }
}
