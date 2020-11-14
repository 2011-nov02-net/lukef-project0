using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class StoreInventory
    {
        public string StoreInventoryId { get; set; }
        public string LocationId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
