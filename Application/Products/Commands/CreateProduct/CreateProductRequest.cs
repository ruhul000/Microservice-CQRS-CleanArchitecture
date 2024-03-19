namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductRequest(string Name, string? Description, decimal? Price);
