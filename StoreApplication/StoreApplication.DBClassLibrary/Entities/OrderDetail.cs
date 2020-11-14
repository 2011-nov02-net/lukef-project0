using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class OrderDetail
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
