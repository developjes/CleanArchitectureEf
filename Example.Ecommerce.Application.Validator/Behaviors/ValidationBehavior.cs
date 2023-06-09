﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using FluentValidationException = Example.Ecommerce.Application.Validator.Exceptions.FluentValidationException;

namespace Example.Ecommerce.Application.Validator.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest :
    IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
        _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            ValidationContext<TRequest> context = new(request);

            ValidationResult[] validationResults = await Task
                .WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            List<ValidationFailure> failures = validationResults
                .SelectMany(r => r.Errors).Where(f => f is not null).ToList();

            if (failures.Any()) throw new FluentValidationException(failures);
        }

        return await next();
    }
}