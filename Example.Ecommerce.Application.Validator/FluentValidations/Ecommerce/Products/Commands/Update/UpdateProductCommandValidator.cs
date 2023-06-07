using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Update;
using FluentValidation;

namespace Example.Ecommerce.Application.Validator.FluentValidations.Ecommerce.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandDto>
{
    public UpdateProductCommandValidator() => DefineRules();

    private void DefineRules()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Can't be null or empty");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Can't be null or empty");

        RuleFor(p => p.Seller)
            .NotEmpty().WithMessage("Can't be null or empty");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.Stock)
            .GreaterThan(0).WithMessage("Can be greater 0");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Can be greater 0");
    }
}