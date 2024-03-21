using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Mapster;

namespace Application.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Result<ProductResponse>>
{
    private readonly IProductQueryRepository _productQueryRepository;
    public GetProductByIdQueryHandler(IProductQueryRepository productQueryRepository) => _productQueryRepository = productQueryRepository;

    public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productQueryRepository.GetProductById(request.ProductId);
        
        if(product is null)
        {
            return Result<ProductResponse>.Failure(new Error("GetProductById", $"The product with the identifier {request.ProductId} was not found."));
        }

        return Result<ProductResponse>.Success(product.Adapt<ProductResponse>()); 
    }

}
