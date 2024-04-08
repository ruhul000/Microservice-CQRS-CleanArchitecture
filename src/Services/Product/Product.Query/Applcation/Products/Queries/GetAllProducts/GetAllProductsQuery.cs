using Application.Abstractions.Messaging;

namespace Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IQuery<Result<IEnumerable<ProductResponse>>>;

