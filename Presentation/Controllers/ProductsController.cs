using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Presentation.Controllers;

public sealed class ProductsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FormBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProdcutCommand>();
        var productId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetProduct), new { productId }, productId);
    }
}
