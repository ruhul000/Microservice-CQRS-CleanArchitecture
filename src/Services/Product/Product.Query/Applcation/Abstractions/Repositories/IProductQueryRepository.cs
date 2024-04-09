using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IProductQueryRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(string id);
    Task<Product?> GetProductByName(string name);
}
