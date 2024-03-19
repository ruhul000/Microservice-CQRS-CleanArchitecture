using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Exceptions;
using Mapster;

namespace Application.Products.Queries.GetProductById;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetProductById(request.ProductId);
        
        if(product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        return product.Adapt<ProductResponse>(); ;
    }

}
