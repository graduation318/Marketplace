namespace Marketplace.Service.ModelsRequest;

public class ProductCharacteristicRequest
{
    public int ProductId { get; set; }
    public int CharacteristicId { get; set; }
    public string? Value { get; set; }
}