using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Customer
    {
        private string _firstname;
        private string _lastname;
        private int _customerid;

        public string FirstName { get => _firstname; private set => _firstname = value; }
        public string LastName { get => _lastname; private set => _lastname = value; }
        public int CustomerId { get => _customerid; private set => _customerid = value; }

        public Customer(string firstName, string lastName, int customerId )
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerId = customerId;
        }

    }
}
