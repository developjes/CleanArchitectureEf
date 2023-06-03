using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.Exceptions;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandDto, int>
{
    private readonly IMapper _mapper;
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(
        IMapper mapper,
        IEfUnitOfWork efUnitOfWork,
        ILogger<CreateProductCommandHandler> logger)
    {
        _mapper = mapper;
        _efUnitOfWork = efUnitOfWork;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProductCommandDto request, CancellationToken cancellationToken)
    {
        ProductEntity productEntity = _mapper.Map<ProductEntity>(request);

        await _efUnitOfWork.EfRepository<ProductEntity>().Insert(productEntity);
        int isSaved = await _efUnitOfWork.EfSave(cancellationToken: cancellationToken);

        if (isSaved <= 0)
        {
            _logger.LogError("No se inserto el record del director");
            throw new ArgumentException("No se pudo insertar el record del director");
        }

        return productEntity.Id;
    }
}