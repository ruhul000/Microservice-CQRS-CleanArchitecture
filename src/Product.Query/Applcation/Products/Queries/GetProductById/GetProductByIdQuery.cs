using System;
using Application.Abstractions.Messaging;

namespace Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<Result<ProductResponse>>;

