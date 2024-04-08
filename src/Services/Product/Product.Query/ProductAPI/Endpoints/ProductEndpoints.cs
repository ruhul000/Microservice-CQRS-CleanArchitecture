using Application.Products.Queries.GetAllProducts;
using Application.Products.Queries.GetProductById;
using Application.Products.Queries.GetProductByName;
using MediatR;

namespace ProductAPI.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductQueries(this IEndpointRouteBuilder app)
    {
        app.MapGet("Products/", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetAllProductsQuery();

            var result = await sender.Send(query, cancellationToken);

            return result;
        }).MapToApiVersion(1);

        app.MapGet("ProductById/{productId}", async (string productId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProductByIdQuery(productId);

            var result = await sender.Send(query, cancellationToken);

            return result;
        }).MapToApiVersion(1);

        app.MapGet("ProductByName/{productName}", async (string productName, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProductByNameQuery(productName);

            var result = await sender.Send(query, cancellationToken);

            return result;
        }).MapToApiVersion(2);
    }
}
