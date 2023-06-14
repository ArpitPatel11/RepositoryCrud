namespace PracticeApp.Models
{
    public class Product
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductPrice { get; set; } = string.Empty;
    }
}
