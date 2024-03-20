using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Mapster;

namespace Application.Products.Queries.GetProductById;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductByIdQuery, Result<ProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetProductById(request.ProductId);
        
        if(product is null)
        {
            return Result<ProductResponse>.Failure(new Error("GetProductById", $"The product with the identifier {request.ProductId} was not found."));
        }

        return Result<ProductResponse>.Success(product.Adapt<ProductResponse>()); 
    }

}
