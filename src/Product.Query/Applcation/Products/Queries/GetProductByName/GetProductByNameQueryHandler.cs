using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Mapster;

namespace Application.Products.Queries.GetProductByName;

public sealed class GetProductByNameQueryHandler : IQueryHandler<GetProductByNameQuery, Result<ProductResponse>>
{
    private readonly IProductQueryRepository _productQueryRepository;
    public GetProductByNameQueryHandler(IProductQueryRepository productQueryRepository) => _productQueryRepository = productQueryRepository;

    public async Task<Result<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _productQueryRepository.GetProductByName(request.Name);

        if(product is null)
        {
            return Result<ProductResponse>.Failure(new Error("GetProductByName", $"The product with the identifier {request.Name} was not found."));
        }

        return Result<ProductResponse>.Success(product.Adapt<ProductResponse>()); 
    }

}
