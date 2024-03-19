using Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Builder;
using System.Threading;

namespace ProductAPI.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/product/{productId}", async (Guid productId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProductByIdQuery(productId);

            var Product = await sender.Send(query, cancellationToken);

            return Product;
        });
    }
}
