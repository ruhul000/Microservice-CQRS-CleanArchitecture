namespace Application.Products.Queries.GetWebinarById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductResponse>;

