using AutoMapper;
using Example.Ecommerce.Application.Interface.Persistence.ExternalServices;
using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Transversal.Common.Generic;
using Example.Ecommerce.Domain.Entities.ExternalServices;
using Example.Ecommerce.Application.Interface.UseCases.Petition;
using System.Text.Json.Nodes;
using System.Text.Json;
using System;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;

namespace Example.Ecommerce.Application.UseCases.Petition
{
    internal class GoRestPostApplication : IGoRestPostApplication
    {
        private readonly IEfUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRestService _restService;

        public GoRestPostApplication(IEfUnitOfWork unitOfWork, IMapper mapper, IRestService restService) =>
            (_unitOfWork, _mapper, _restService) = (unitOfWork, mapper, restService);

        public async Task<Response<List<GoRestGetPostDto>>> GetPosts()
        {
            Response<List<GoRestGetPostDto>> response = new();

            string url = "https://gorest.co.in/public/v2/posts";
            response.Data = _mapper.Map<List<GoRestGetPostDto>>(await _restService.GetJson<IEnumerable<GoRestGetPostData>>(url));

            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = new()
                {
                    Key = "Success",
                    Description = "Consulta Exitosa!!!"
                };
            }

            return response;
        }

        /*
        public static bool IsJsonValid<TSchema>(this string value)
        {

            bool res = true;
            var obj = JsonConvert.DeserializeObject<List<TSchema>>(value);

            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(TSchema));

            JArray actualJson = JArray.Parse(value);
            bool valid = actualJson.IsValid(schema);

            return valid;
        }
        */

        public async Task<Response<GoRestCreatePostDto>> CreatePosts(GoRestCreatePostDto post)
        {
            Response<GoRestCreatePostDto> response = new();

            string url = "https://gorest.co.in/public/v2/posts";
            Dictionary<string, string> headers = new()
            {
                { "Authorization", "Bearer 2194850af38f86259cfd0d95421f1d6c9727bcfc727a5f34a4ad93a90e103631" },
                { "Accept", "application/json" },
            };
            string contentType = "application/json";

            response.Data = _mapper.Map<GoRestCreatePostDto>(
                await _restService.PostJson<GoRestCreatePostDto, GoRestPostPostData>(url, contentType, post, headers)
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

            return response;
        }
    }
}
