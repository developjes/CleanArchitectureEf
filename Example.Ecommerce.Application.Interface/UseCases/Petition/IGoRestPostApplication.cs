using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface.UseCases.Petition
{
    public interface IGoRestPostApplication
    {
        Task<Response<List<GoRestGetPostDto>>> GetPosts();
        Task<Response<GoRestCreatePostDto>> CreatePosts(GoRestCreatePostDto post);
    }
}