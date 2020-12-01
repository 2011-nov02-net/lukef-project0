namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Product()
        {

        }

        public Product(int productId, string title, decimal price)

        {
            ProductId = productId;
            Title = title;
            Price = price;
        }

    }
}
