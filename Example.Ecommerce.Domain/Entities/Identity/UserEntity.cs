using Microsoft.AspNetCore.Identity;

namespace Example.Ecommerce.Domain.Entities.Identity;

public class UserEntity : IdentityUser
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Telephone { get; set; }
    public string? AvatarUrl { get; set; }
    public bool IsActive { get; set; } = true;
}