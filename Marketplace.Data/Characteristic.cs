namespace Shop.Data
{
    public class Characteristic : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public List<ProductCharacteristic> ProductCharacteristics { get; set; } = new List<ProductCharacteristic>();
    }
}