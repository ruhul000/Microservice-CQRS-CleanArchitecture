
using Domain.Entities;

namespace Domain.Abstractions;

public interface IProductRepository
{
    void Insert(Product product);
}
