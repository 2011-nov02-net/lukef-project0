using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
