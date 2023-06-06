using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.DTO.Features.Shared.Create;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Create;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandDto, CreateIdResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly BusinessValidationCreateProduct _businessValidationCreateProduct;

    public CreateProductCommandHandler(
        IMapper mapper, IEfUnitOfWork efUnitOfWork, BusinessValidationCreateProduct businessValidationCreateProduct
    )
    {
        _mapper = mapper;
        _efUnitOfWork = efUnitOfWork;
        _businessValidationCreateProduct = businessValidationCreateProduct;
    }

    public async Task<CreateIdResponseDto> Handle(CreateProductCommandDto request, CancellationToken cancellationToken)
    {
        // Business validations
        await _businessValidationCreateProduct.CreateValidate(request);

        // Mapper entity
        ProductEntity productEntity = _mapper.Map<ProductEntity>(request);
        productEntity.StateId = (int)EProductState.Active;

        // Store Product
        await _efUnitOfWork.EfRepository<ProductEntity>().Insert(productEntity);

        // Validation for save changes
        if (await _efUnitOfWork.EfSave(cancellationToken: cancellationToken) <= sbyte.MinValue) // Commit changes
            throw new DbUpdateException($"Can't be inserted sucessfull. Afected rows {sbyte.MinValue}"); // Exception validation

        // Return Response
        return new CreateIdResponseDto { Id = productEntity.Id };
    }
}