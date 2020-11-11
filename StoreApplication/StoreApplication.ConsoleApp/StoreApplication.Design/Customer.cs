using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Customer
    {
        public int _customerid = 0;
        private string _customername;

        public string CustomerName { get => _customername; private set => _customername = value; }

        public Customer(string customerName, int customerId)
        {
            customerId = _customerid;
            CustomerName = customerName;
            _customerid += 1;

        }

    }
}
