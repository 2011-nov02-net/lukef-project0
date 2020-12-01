﻿using System;

#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
