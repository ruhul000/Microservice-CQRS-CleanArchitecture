namespace Application.Products.Queries;

public sealed record ProductResponse(string Id, string Name, string? Description, decimal? Price);

