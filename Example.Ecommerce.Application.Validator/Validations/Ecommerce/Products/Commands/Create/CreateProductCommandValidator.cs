using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using FluentValidation;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandDto>
{
    public CreateProductCommandValidator() => DefineRules();

    private void DefineRules()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("{Name} can't be null")
            .NotEmpty().WithMessage("{Name} can't be empty");

        RuleFor(p => p.Description)
            .NotNull().WithMessage("{Description} can't be null")
            .NotEmpty().WithMessage("{Description} can't be empty");

        RuleFor(p => p.Seller)
            .NotNull().WithMessage("{Description} can't be null")
            .NotEmpty().WithMessage("{Description} can't be empty");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{Description} can't be empty")
            .GreaterThanOrEqualTo(1).WithMessage("{Description} can be greater 0");

        RuleFor(p => p.Rating)
            .NotEmpty().WithMessage("{Description} can't be empty")
            .GreaterThanOrEqualTo(1).WithMessage("{Description} can be greater 0");

        RuleFor(p => p.Stock)
            .NotEmpty().WithMessage("{Description} can't be empty")
            .GreaterThanOrEqualTo(1).WithMessage("{Description} can be greater 0");

        RuleFor(p => p.StateId)
            .NotNull().WithMessage("{Description} can't be empty")
            .GreaterThanOrEqualTo(1).WithMessage("{Description} can be greater 0");

        RuleFor(p => p.CategoryId)
            .NotNull().WithMessage("{Description} can't be empty")
            .GreaterThanOrEqualTo(1).WithMessage("{Description} can be greater 0"); ;
    }
}