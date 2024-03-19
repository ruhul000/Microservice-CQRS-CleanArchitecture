
using Domain.Entities;

namespace Domain.Abstractions;

public interface IProductRepository
{
    Task<ICollection<Product>> GetAllProduct();
    Task<Product?> GetProductById(Guid id);
    void AddProduct(Product product);
}
