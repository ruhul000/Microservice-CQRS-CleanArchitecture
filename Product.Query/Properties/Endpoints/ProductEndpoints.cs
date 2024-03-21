using Application.Products.Queries.GetAllProducts;
using Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Builder;
using System.Threading;

namespace Product.Command.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/products/", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetAllProductsQuery();

            var result = await sender.Send(query, cancellationToken);

            return result;
        });

        app.MapGet("api/product/{productId}", async (Guid productId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProductByIdQuery(productId);

            var result = await sender.Send(query, cancellationToken);

            return result;
        });
    }
}
