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
    private ILogger<ProductController> _logger;
    private readonly ISender _sender;
    public ProductController(ILogger<ProductController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

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
            _logger.LogError("Error: {Error}, {@DateTimeUtc}", result.Error, DateTime.UtcNow);
            return BadRequest(result);
        }

        return Ok(result);
    }
}
