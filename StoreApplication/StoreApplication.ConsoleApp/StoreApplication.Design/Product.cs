using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {

        }

        public Product(int productId, string title, double price, int quantity)

        {
            ProductId = productId;
            Title = title;
            Price = price;
            Quantity = quantity;
        }

    }
}
