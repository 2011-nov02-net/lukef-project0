namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class StoreInventory
    {
        public int StoreInventoryId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public StoreInventory(int storeInventoryId, int locationId, int productId, int quantity)
        {
            StoreInventoryId = storeInventoryId;

        }
    }
}
