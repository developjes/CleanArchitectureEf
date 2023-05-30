using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.DTO.Features.Shared;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.UseCases.Specifications.Product;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using MediatR;

namespace Example.Ecommerce.Application.UseCases.Features.Products.Queries.PaginationProductList;

public class PaginationProductListQueryHandler :
    IRequestHandler<PaginationProductListQuery, PaginationDto<ProductResponseDto>>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly IMapper _mapper;

    public PaginationProductListQueryHandler(IEfUnitOfWork efUnitOfWork, IMapper mapper) =>
        (_efUnitOfWork, _mapper) = (efUnitOfWork, mapper);

    public async Task<PaginationDto<ProductResponseDto>> Handle(
        PaginationProductListQuery request, CancellationToken cancellationToken)
    {
        ProductSpecificationParams productSpecificationParams = _mapper.Map<ProductSpecificationParams>(request);

        int totalProducts = await _efUnitOfWork
            .EfRepository<ProductEntity>().CountAsync(new ProductForCountingSpecification(productSpecificationParams));

        IReadOnlyList<ProductEntity> products = await _efUnitOfWork
            .EfRepository<ProductEntity>().GetAllWithSpec(new ProductSpecification(productSpecificationParams));

        IReadOnlyList<ProductResponseDto> data = _mapper.Map<IReadOnlyList<ProductResponseDto>>(products);

        return new()
        {
            Count = totalProducts,
            Data = data,
            PageCount = (int)Math.Ceiling(Convert.ToDecimal(totalProducts) / Convert.ToDecimal(request.PageSize)),
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = products.Count
        };
    }
}