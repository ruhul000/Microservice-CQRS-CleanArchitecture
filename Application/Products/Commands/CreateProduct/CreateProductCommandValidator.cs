using Domain.Abstractions;
using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required!")
            .Must(ProductNameUnique).WithMessage("Product name already exist!");
    }

    private bool ProductNameUnique(string ProductName)
        => !_unitOfWork.ProductRepository.IsProductNameExist(ProductName).Result;
}