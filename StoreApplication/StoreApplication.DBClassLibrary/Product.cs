using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
