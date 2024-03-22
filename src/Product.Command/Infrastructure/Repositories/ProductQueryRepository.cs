using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class ProductQueryRepository : IProductQueryRepository
{
    private readonly ProductReadDbContext _dbContext;

    public ProductQueryRepository(ProductReadDbContext dbContext) => _dbContext = dbContext;

    public async Task<bool> IsProductNameExist(string name)
      => name != "" ? await _dbContext.Products.AnyAsync(obj => obj.Name == name) : false;
    public async Task<IEnumerable<Product>> GetAllProducts() 
        => await _dbContext.Products.ToListAsync() ?? Enumerable.Empty<Product>();
    
    public async Task<Product?> GetProductById(Guid id)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product?> GetProductByName(string name)
       => await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == name);

}