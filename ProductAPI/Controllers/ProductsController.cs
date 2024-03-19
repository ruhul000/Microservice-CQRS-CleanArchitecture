using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductById;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/product")]
public sealed class ProductsController : ControllerBase
{
    private readonly ISender _sender;
    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    //[HttpGet("{productId:guid}")]
    //[ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetProduct(Guid productId, CancellationToken cancellationToken)
    //{
    //    var query = new GetProductByIdQuery(productId);

    //    var Product = await _sender.Send(query, cancellationToken);

    //    return Ok(Product);
    //}

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();

        var ProductId = await _sender.Send(command, cancellationToken);

        return CreatedAtAction("CreateProduct", new { ProductId }, ProductId);
    }
}
