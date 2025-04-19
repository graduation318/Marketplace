namespace Marketplace.Service.CustomException;

public class MissingDirectionException: System.Exception
{
    public MissingDirectionException(string? message) : base(message)
    {
    }
}