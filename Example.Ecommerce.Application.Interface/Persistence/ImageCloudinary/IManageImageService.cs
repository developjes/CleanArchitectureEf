using Example.Ecommerce.Application.DTO.ImageManagement.Request;
using Example.Ecommerce.Application.DTO.ImageManagement.Response;

namespace Example.Ecommerce.Application.Interface.Persistence.ImageCloudinary;

public interface IManageImageService
{
    Task<ImageResponse> UploadImage(ImageDataRequest imageDataResquestDto);
}