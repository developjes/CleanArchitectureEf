using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using FluentValidation;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandDto>
{
    public CreateProductCommandValidator() => DefineRules();

    private void DefineRules()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("{Name} can't be null");
        RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("{Description} can't be null");
        RuleFor(p => p.Seller).NotNull().NotEmpty().WithMessage("{Seller} can't be null");
        RuleFor(p => p.Price).NotNull().Must(p => p > 0).WithMessage("{Price} can be major to 0");
        RuleFor(p => p.Rating).NotNull().Must(p => p > 0).WithMessage("{Rating} can be major to 0");
        RuleFor(p => p.Stock).NotNull().Must(p => p > 0).WithMessage("{Stock} can be major to 0");

        RuleFor(p => p.StateId).NotNull().Must(p => p > 0).WithMessage("{StateId} can be major to 0");
        RuleFor(p => p.CategoryId).NotNull().Must(p => p > 0).WithMessage("{CategoryId} can be major to 0");
    }
}