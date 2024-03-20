using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Exceptions;
using Mapster;
using System.Collections.Generic;

namespace Application.Products.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, Result<IEnumerable<ProductResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllProducts();

        if (!products.Any())
        {
            return Result<IEnumerable<ProductResponse>>.Failure(new Error("GetAllProducts", "Products not found!"));
        }

        return Result<IEnumerable<ProductResponse>>.Success(products.Adapt<IEnumerable<ProductResponse>>()) ;
    }

}
