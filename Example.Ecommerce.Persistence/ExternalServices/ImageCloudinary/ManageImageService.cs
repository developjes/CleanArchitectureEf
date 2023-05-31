using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Example.Ecommerce.Application.DTO.ImageManagement.Request;
using Example.Ecommerce.Application.DTO.ImageManagement.Response;
using Example.Ecommerce.Application.Interface.Persistence.ImageCloudinary;
using Example.Ecommerce.Persistence.Models.Configuration;
using Microsoft.Extensions.Options;
using System.Net;

namespace Example.Ecommerce.Persistence.ExternalServices.ImageCloudinary;

public class ManageImageService : IManageImageService
{
    public CloudinarySettings CloudinarySettings { get; }

    public ManageImageService(IOptions<CloudinarySettings> cloudinarySettings) =>
        CloudinarySettings = cloudinarySettings.Value;

    public async Task<ImageResponse> UploadImage(ImageDataRequest imageDataResquestDto)
    {
        Account account = new(CloudinarySettings.CloudName, CloudinarySettings.ApiKey, CloudinarySettings.ApiSecret);
        ImageUploadParams uploadImage = new()
        {
            File = new FileDescription(imageDataResquestDto.Name, imageDataResquestDto.ImageStream)
        };

        Cloudinary cloudinary = new(account);

        try
        {
            ImageUploadResult uploadResult = await cloudinary.UploadAsync(uploadImage);

            if (uploadResult.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(
                    $"{nameof(uploadResult.StatusCode)} {uploadResult.StatusCode}", uploadResult.Error.Message);
            }

            return new ImageResponse { PublicId = uploadResult.PublicId, Url = uploadResult.Url.ToString() };
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message, ex.InnerException);
        }
    }
}