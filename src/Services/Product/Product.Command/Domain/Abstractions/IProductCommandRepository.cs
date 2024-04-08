using Domain.Entities;

namespace Domain.Abstractions;

public interface IProductCommandRepository
{
    void AddProduct(Product product);
}
