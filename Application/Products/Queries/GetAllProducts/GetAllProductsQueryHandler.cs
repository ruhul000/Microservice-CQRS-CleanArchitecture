using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Mapster;

namespace Application.Products.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, Result<IEnumerable<ProductResponse>>>
{
    private readonly IProductQueryRepository _productQueryRepository;
    public GetAllProductsQueryHandler(IProductQueryRepository productQueryRepository) => _productQueryRepository = productQueryRepository;

    public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productQueryRepository.GetAllProducts();

        if (!products.Any())
        {
            return Result<IEnumerable<ProductResponse>>.Failure(new Error("GetAllProducts", "Products not found!"));
        }

        return Result<IEnumerable<ProductResponse>>.Success(products.Adapt<IEnumerable<ProductResponse>>()) ;
    }

}
