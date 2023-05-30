using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using System.Linq.Expressions;

namespace Example.Ecommerce.Application.UseCases.Features.Products.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IReadOnlyList<ProductResponseDto>>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IEfUnitOfWork efUnitOfWork, IMapper mapper) =>
        (_efUnitOfWork, _mapper) = (efUnitOfWork, mapper);

    public async Task<IReadOnlyList<ProductResponseDto>> Handle(
        GetProductListQuery request, CancellationToken cancellationToken)
    {
        List<Expression<Func<ProductEntity, object>>> includes = new() { p => p.ProductImages!, p => p.Reviews! };

        IReadOnlyList<ProductEntity> products = await _efUnitOfWork.EfRepository<ProductEntity>().Get(
            false
            ,filter: f => f.StateId == (int)EProductState.Active
            ,orderBy: x => x.OrderBy(y => y.Name)
            ,includeProperties: includes
            ,cancellationToken: cancellationToken
        );

        return _mapper.Map<IReadOnlyList<ProductResponseDto>>(products);
    }
}