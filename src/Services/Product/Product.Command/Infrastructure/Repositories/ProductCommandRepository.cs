using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class ProductCommandRepository : IProductCommandRepository
{
    private readonly ProductWriteDbContext _dbContext;

    public ProductCommandRepository(ProductWriteDbContext dbContext) => _dbContext = dbContext;


    public async void AddProduct(Product product) 
        => await _dbContext.AddAsync(product);
}