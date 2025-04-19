namespace Marketplace.Service.ModelsRequest;

public class BaseModelRequest
{
    public BaseModelRequest()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}