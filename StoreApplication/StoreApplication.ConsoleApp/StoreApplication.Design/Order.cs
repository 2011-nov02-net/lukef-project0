using System;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Order
    {

        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderTime { get ; set; }
        public int Quantity { get; set; }

        public Order()
        {

        }

        public Order(int locationId , int customerId, int productId,  int quantity)
        {
            LocationId = locationId;
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
            OrderTime = DateTime.Now;
        }
    }
}
