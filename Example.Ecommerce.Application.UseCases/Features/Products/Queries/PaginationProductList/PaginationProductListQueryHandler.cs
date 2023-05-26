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
        ProductSpecificationParams productSpecificationParams = new()
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort,
            MaxPrice = request.MaxPrice,
            MinPrice = request.MinPrice,
            Rating = request.Rating,
            StateId = request.State
        };

        ProductForCountingSpecification specCount = new(productSpecificationParams);
        int totalProducts = await _efUnitOfWork.EfRepository<ProductEntity>().CountAsync(specCount);

        ProductSpecification spec = new(productSpecificationParams);
        IReadOnlyList<ProductEntity> products = await _efUnitOfWork.EfRepository<ProductEntity>().GetAllWithSpec(spec);

        decimal rounded = Math.Ceiling(Convert.ToDecimal(totalProducts) / Convert.ToDecimal(request.PageSize));
        IReadOnlyList<ProductResponseDto> data = _mapper.Map<IReadOnlyList<ProductResponseDto>>(products);

        return new()
        {
            Count = totalProducts,
            Data = data,
            PageCount = (int)rounded,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = products.Count
        };
    }
}