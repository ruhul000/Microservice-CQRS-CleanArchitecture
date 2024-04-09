using Application.Abstractions.Repositories;
using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IProductQueryRepository _productQueryRepository;
    public CreateProductCommandValidator(IProductQueryRepository productQueryRepository)
    {
        _productQueryRepository = productQueryRepository;

        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required!")
            .Must(ProductNameUnique).WithMessage("Product name already exist!");
    }

    private bool ProductNameUnique(string ProductName)
        => !_productQueryRepository.IsProductNameExist(ProductName).Result;
}