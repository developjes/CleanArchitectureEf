using Example.Ecommerce.Application.DTO.Parametrization.Response;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface.UseCases.Parametrization
{
    public interface IStatesApplication
    {
        Task<Response<IEnumerable<StateDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<Response<StateDto>> GetById(int id, CancellationToken cancellationToken = default);
        Task<Response<IEnumerable<StateDto>>> GetByIdSP(int id);
    }
}