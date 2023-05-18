using FluentValidation.Results;

namespace Example.Ecommerce.Transversal.Common.Generic
{
    public abstract class ResponseGeneric<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public ResponseMessage? Message { get; set; }
        public IEnumerable<ValidationFailure>? InputDataErrors { get; set; }
    }
}