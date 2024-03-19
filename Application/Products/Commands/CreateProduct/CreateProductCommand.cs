using Application.Abstractions.Messaging;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string? Description, decimal? Price) : ICommand<Guid>;

