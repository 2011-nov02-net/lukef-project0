using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Product
    {
        private string _title;
        private double _price;
        private int _quantity;

        public string Title { get => _title; private set => _title = value; }
        public double Price { get => _price; private set => _price = value; }
        public int Quantity { get => _quantity; private set => _quantity = value; }


        public Product(string title, double price, int quantity)

        {
            Title = title;
            Price = price;
            Quantity = quantity;
        }

    }
}
