namespace Marketplace.Data
{
    public class ProductCharacteristic
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}