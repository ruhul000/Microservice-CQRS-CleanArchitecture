using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IProductCommandRepository
{
    void AddProduct(Product product);
}
