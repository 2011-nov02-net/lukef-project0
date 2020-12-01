#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class StoreInventory
    {
        public int StoreInventoryId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
