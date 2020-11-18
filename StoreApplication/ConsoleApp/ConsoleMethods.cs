using StoreApplication.ClassLibrary.StoreApplication.Design;
using StoreApplication.DBClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class ConsoleMethods
    {
        public static StoreRepository storeRepository { get; set; }



        public static Location GetLocationByName(string name)
        {
            return storeRepository.GetLocationByName(name);
        }

        public static Product GetProductByName(string name)
        {
            return storeRepository.GetProductByName(name);
        }

        public static Customer GetCustomerByName(string firstName, string lastName)
        {
            return storeRepository.GetCustomerByName(firstName, lastName);
        }

        public void InsertCustomer(Customer customer)
        {
            storeRepository.InsertCustomer(customer);
        }

        public void InsertOrder(Order order)
        {
            storeRepository.InsertOrder(order);
        }

        //public List<Order> GetCustomerOrders(Customer customer)
        //{
        //    //return storeRepository.GetCustomerOrders(customer);
        //}

        //public List<Order> GetLocationOrders(Location location)
        //{
        //    //return storeRepository.GetLocationOrders(location);
        //}
    }
}
