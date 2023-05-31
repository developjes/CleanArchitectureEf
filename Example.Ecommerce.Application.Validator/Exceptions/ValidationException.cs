using FluentValidation.Results;

namespace Example.Ecommerce.Application.Validator.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException() : base("Se presentaron uno o mas errores de validation") =>
        Errors = new Dictionary<string, string[]>();

    public ValidationException(string message) : base(message) => Errors = new Dictionary<string, string[]>();

    public ValidationException(string message, Exception innerException) : base(message, innerException) =>
        Errors = new Dictionary<string, string[]>();

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}