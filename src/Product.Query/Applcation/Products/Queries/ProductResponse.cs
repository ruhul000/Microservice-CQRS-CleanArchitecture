namespace Application.Products.Queries;

public sealed record ProductResponse(Guid Id, string Name, string? Description, decimal? Price);

