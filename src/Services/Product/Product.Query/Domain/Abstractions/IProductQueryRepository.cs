using Domain.Entities;

namespace Domain.Abstractions;

public interface IProductQueryRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(string id);
    Task<Product?> GetProductByName(string name);
}
