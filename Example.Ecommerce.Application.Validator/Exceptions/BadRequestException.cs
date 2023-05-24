namespace Example.Ecommerce.Application.Validator.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message) { }
}