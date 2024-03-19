using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(Guid.NewGuid(), request.Name, request.Description, request.Price);

        _unitOfWork.ProductRepository.AddProduct(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;

    }
}
