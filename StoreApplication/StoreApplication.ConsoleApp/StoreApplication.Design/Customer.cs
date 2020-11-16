using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Dictionary<Product, int> ShoppingCart { get; set; }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string email )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ShoppingCart = new Dictionary<Product, int>();
        }

    }
}
