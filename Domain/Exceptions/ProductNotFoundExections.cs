namespace Domain.Exceptions;

public sealed class ProductNotFoundException : NotFoundExcetion
{
    public ProductNotFoundException(Guid productId)
        : base($"The product with the identifier {productId} was not found.")
    {
    }
}
