namespace Application.Products.Queries.GetProductById;

public sealed record ProductResponse(Guid Id, string Name, string? Description, decimal? Price);

