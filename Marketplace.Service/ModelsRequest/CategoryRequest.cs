namespace Marketplace.Service.ModelsRequest;

public class CategoryRequest : BaseModelRequest
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
