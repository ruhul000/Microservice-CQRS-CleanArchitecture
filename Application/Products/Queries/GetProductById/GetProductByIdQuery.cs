using System;
using Application.Abstractions.Messaging;
using Application.Products.Queries.GetProductById;

namespace Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductResponse>;

