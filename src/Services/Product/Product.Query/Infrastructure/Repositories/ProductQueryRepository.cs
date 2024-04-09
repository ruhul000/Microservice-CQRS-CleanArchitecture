using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public sealed class ProductQueryRepository : IProductQueryRepository
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductQueryRepository(IMongoDatabase mongoDatabase) => _productCollection = mongoDatabase.GetCollection<Product>("Products");

    public async Task<IEnumerable<Product>> GetAllProducts()
        => await _productCollection.Find(_=>true).ToListAsync() ?? Enumerable.Empty<Product>();

    public async Task<Product?> GetProductById(string id)
        => await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<Product?> GetProductByName(string name)
       => await _productCollection.Find(p => p.Name == name).FirstOrDefaultAsync();

}
