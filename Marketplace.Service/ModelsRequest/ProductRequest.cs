namespace Marketplace.Service.ModelsRequest;

public class ProductRequest : BaseModelRequest
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    // Дополнительно: характеристики при создании/редактировании
    public List<ProductCharacteristicRequest>? Characteristics { get; set; }
}