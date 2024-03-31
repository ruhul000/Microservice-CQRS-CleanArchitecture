using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
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

//public class GuidSerializer : SerializerBase<Guid>
//{
//    public override Guid Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
//    {
//        var bsonType = context.Reader.GetCurrentBsonType();
//        switch (bsonType)
//        {
//            case BsonType.String:
//                var value = context.Reader.ReadString();
//                return Guid.Parse(value);
//            default:
//                throw new NotSupportedException($"Cannot deserialize a 'Guid' from BsonType '{bsonType}'.");
//        }
//    }

//    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Guid value)
//    {
//        context.Writer.WriteString(value.ToString());
//    }
//}

//public sealed class ProductQueryRepository : IProductQueryRepository
//{
//    private readonly ProductReadDbContext _dbContext;

//    public ProductQueryRepository(ProductReadDbContext dbContext) => _dbContext = dbContext;

//    public async Task<bool> IsProductNameExist(string name)
//      => name != "" ? await _dbContext.Products.AnyAsync(obj => obj.Name == name) : false;
//    public async Task<IEnumerable<Product>> GetAllProducts()
//        => await _dbContext.Products.ToListAsync() ?? Enumerable.Empty<Product>();

//    public async Task<Product?> GetProductById(Guid id)
//        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

//    public async Task<Product?> GetProductByName(string name)
//       => await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == name);

//}