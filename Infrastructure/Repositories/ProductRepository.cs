using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository(ProductDbContext dbContext) => _dbContext = dbContext;

    public async Task<ICollection<Product>> GetAllProduct() 
        => await _dbContext.Products.ToListAsync();
    
    public async Task<Product?> GetProductById(Guid id)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async void AddProduct(Product product) 
        => await _dbContext.AddAsync(product);
}