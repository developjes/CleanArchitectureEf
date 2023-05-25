using Example.Ecommerce.Domain.Entities.Identity;

namespace Example.Ecommerce.Application.Interface.Identity;

public interface IAuthService
{
    string GetSessionUser();
    string CreateToken(UserEntity user, IList<string>? roles);
}