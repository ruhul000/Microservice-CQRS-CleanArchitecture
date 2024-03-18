namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string Description, double Price) : ICommand<Guid>;

