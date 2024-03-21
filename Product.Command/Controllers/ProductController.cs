using Application.Products.Commands.CreateProduct;
using Asp.Versioning;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/Product")]
[ApiVersion("1")]
public sealed class ProductController : ControllerBase
{
    private readonly ISender _sender;
    public ProductController(ISender sender)
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
    [MapToApiVersion("1")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
