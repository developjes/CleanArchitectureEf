using FluentValidation.Results;

namespace Example.Ecommerce.Application.Validator.Exceptions;

public class FluentValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public FluentValidationException() : base("One or more validation failures have occurred.") =>
        Errors = new Dictionary<string, string[]>();

    public FluentValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}