using System;
using Application.Abstractions.Messaging;

namespace Application.Products.Queries.GetProductByName;

public sealed record GetProductByNameQuery(string Name) : IQuery<Result<ProductResponse>>;

