namespace Shop.Data
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<ProductCharacteristic> Characteristics { get; set; } = new List<ProductCharacteristic>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}