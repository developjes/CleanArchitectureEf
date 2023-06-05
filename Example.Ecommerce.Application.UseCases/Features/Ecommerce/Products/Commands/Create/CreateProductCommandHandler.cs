using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Create;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandDto, CreateProductResponseDto>
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

    public async Task<CreateProductResponseDto> Handle(CreateProductCommandDto request, CancellationToken cancellationToken)
    {
        ProductEntity productEntity = _mapper.Map<ProductEntity>(request);
        productEntity.StateId = (int)EProductState.Active;

        await _efUnitOfWork.EfRepository<ProductEntity>().Insert(productEntity);

        if (await _efUnitOfWork.EfSave(cancellationToken: cancellationToken) <= uint.MinValue)
            throw new DbUpdateException("Can't be inserted sucessfull");

        // Load related data.
        await _efUnitOfWork.LoadRelatedData(productEntity, x => x.Category);
        await _efUnitOfWork.LoadRelatedData(productEntity, x => x.State);

        return _mapper.Map<CreateProductResponseDto>(productEntity);
    }
}