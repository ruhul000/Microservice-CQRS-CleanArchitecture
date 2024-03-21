using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateProductCommand> _productValidator;
    public CreateProductCommandHandler(
        IUnitOfWork unitOfWork,
        IValidator<CreateProductCommand> productValidator) 
    {
        _unitOfWork = unitOfWork;
        _productValidator = productValidator;
    }
    public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _productValidator.ValidateAsync(request);
        if (!result.IsValid)
        {
            var errorMessage = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
            return Result<Product>.Failure(new Error("CreateProduct", errorMessage));
        }

        var product = new Product(Guid.NewGuid(), request.Name, request.Description, request.Price);

        _unitOfWork.ProductCommandRepository.AddProduct(product);

        if(await _unitOfWork.SaveChangesAsync(cancellationToken))
        {
            return Result<Product>.Success(product);
        }

        return Result<Product>.Failure(new Error("CreateProduct", "Something went wrong! Please try again."));

    }
}
