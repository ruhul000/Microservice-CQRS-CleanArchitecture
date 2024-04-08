using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Entities;

public sealed class Product
{
    private Product() { }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; } = String.Empty;

    [BsonRepresentation(BsonType.String)]
    [BsonElement("Id")]
    public string Id { get; set; } = String.Empty;

    [BsonRepresentation(BsonType.String)]
    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    [BsonElement("Description")]
    public string? Description { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    [BsonElement("Price")]
    public decimal? Price { get; set; }
}

