using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductById;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public sealed class ProductsController : ApiController
{
    [HttpGet("{ProductId:guid}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(Guid ProductId, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(ProductId);

        var Product = await Sender.Send(query, cancellationToken);

        return Ok(Product);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();

        var ProductId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetProduct), new { ProductId }, ProductId);
    }
}
