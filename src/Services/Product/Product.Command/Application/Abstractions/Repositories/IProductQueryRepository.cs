using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IProductQueryRepository
{
    Task<bool> IsProductNameExist(string name);
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(Guid id);
    Task<Product?> GetProductByName(string name);

}
