using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Customer
    {
        private int _customerid = 0;
        private string _customername;
        

        public string CustomerName 
        { 
            get => _customername;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: Invalid first name!");
                }
                _customername = value;
            }
        
        }

        public Customer(string customerName, int customerId)
        {
            _customerid = customerId;
            CustomerName = customerName;
            _customerid += 1;


        }




    }
}
