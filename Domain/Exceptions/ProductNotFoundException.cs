using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId)
        : base($"The product with the identifier {productId} was not found.")
    {
    }
}
