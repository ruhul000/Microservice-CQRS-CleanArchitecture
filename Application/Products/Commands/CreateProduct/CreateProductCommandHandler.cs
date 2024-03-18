using Domain.Abstractions;
using Domain.Entities;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    { 
        _productRepository = productRepsitory;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(Guid.NewGuid(), request.Name, request.Description, request.Price);

        _productRepository.Insert(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;

    }
}
