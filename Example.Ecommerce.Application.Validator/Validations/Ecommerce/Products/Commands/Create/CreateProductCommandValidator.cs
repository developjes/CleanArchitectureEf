using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using FluentValidation;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandDto>
{
    public CreateProductCommandValidator() => DefineRules();

    private void DefineRules()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Can't be null or empty");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Can't be null or empty");

        RuleFor(p => p.Seller)
            .NotEmpty().WithMessage("Can't be null or empty");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.Rating)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.Stock)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.StateId)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Can be greater 0");
    }
}