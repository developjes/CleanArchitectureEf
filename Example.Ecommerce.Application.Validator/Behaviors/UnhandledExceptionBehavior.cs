﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Example.Ecommerce.Application.Validator.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest :
        IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehavior(ILogger<TRequest> logger) => _logger = logger;

        public async Task<TResponse> Handle(
            TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try { return await next(); }
            catch (Exception ex)
            {
                string requestName = typeof(TRequest).Name;

                _logger.LogError(
                    ex, "Application Request: Sucedio una exception para el request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}