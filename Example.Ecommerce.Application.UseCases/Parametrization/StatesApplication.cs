using AutoMapper;
using Example.Ecommerce.Application.DTO.Common;
using Example.Ecommerce.Application.DTO.Parametrization.Response;
using Example.Ecommerce.Application.Interface.Persistence;
using Example.Ecommerce.Application.Interface.UseCases.Parametrization;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Transversal.Common.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Example.Ecommerce.Application.UseCases.Parametrization
{
    public class StatesApplication : IStatesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatesApplication(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        /// <summary>
        /// Get all states
        /// </summary>
        /// <param name="cancellationToken">Cancel action</param>
        /// <returns>State Enumerable</returns>
        public async Task<Response<IEnumerable<StateDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            Response<IEnumerable<StateDto>> response = new();

            try
            {
                response.Data = _mapper.Map<List<StateDto>>(await _unitOfWork.StateRepository.Get(
                    asTracking: false,
                    top: 50, skip: 0,
                    includeProperties: new Expression<Func<StateEntity, object>>[] { x => x.Petitions! },
                    cancellationToken: cancellationToken
                ));

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = new()
                    {
                        Key = "Success",
                        Description = "Consulta Exitosa!!!"
                    };
                }
            }
            catch (Exception e)
            {
                response.Message = new()
                {
                    Key = "Error",
                    Description = e.Message
                };
            }

            return response;
        }

        /// <summary>
        /// Get by state id
        /// </summary>
        /// <param name="cancellationToken">Cancel action</param>
        /// <returns>State object</returns>
        public async Task<Response<StateDto>> GetById(int id ,CancellationToken cancellationToken = default)
        {
            Response<StateDto> response = new();

            try
            {
                response.Data = _mapper.Map<StateDto>(await _unitOfWork.StateRepository.GetFirst(
                    asTracking: false,
                    filter: x => x.Id.Equals(id),
                    top: 1, skip: 0,
                    //includeProperties: new Expression<Func<StateEntity, object>>[] { x => x.Petitions! },
                    cancellationToken: cancellationToken
                ));

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = new()
                    {
                        Key = "Success",
                        Description = "Consulta Exitosa!!!"
                    };
                }
            }
            catch (Exception e)
            {
                response.Message = new()
                {
                    Key = "Error",
                    Description = e.Message
                };
            }

            return response;
        }

        public async Task<Response<IEnumerable<StateDto>>> GetByIdSP(int id)
        {
            Response<IEnumerable<StateDto>> response = new();

            try
            {
                response.Data = await _unitOfWork.ExecuteEnumerableSP<StateDto>(
                    "[dbo].[sp_getStatesById]",
                    new List<SqlParam>() { new() { Name = "Id", Value = id, Config = new() { DataType = SqlDbType.Int } } }
                );

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = new()
                    {
                        Key = "Success",
                        Description = "Consulta Exitosa!!!"
                    };
                }
            }
            catch (Exception e)
            {
                response.Message = new()
                {
                    Key = "Error",
                    Description = e.Message
                };
            }

            return response;
        }
    }
}