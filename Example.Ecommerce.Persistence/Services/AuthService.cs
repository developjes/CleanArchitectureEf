using Example.Ecommerce.Application.Interface.Identity;
using Example.Ecommerce.Domain.Entities.Identity;
using Example.Ecommerce.Persistence.Models.Configuration;
using Example.Ecommerce.Transversal.Common.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Example.Ecommerce.Persistence.Services;

public class AuthService : IAuthService
{
    public JwtSettings _jwtSettings { get; }
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IHttpContextAccessor httpContextAccessor, IOptions<JwtSettings> jwtSettings) =>
        (_httpContextAccessor, _jwtSettings) = (httpContextAccessor, jwtSettings.Value);

    public string CreateToken(UserEntity user, IList<string>? roles)
    {
        List<Claim> claims = new(){
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName!),
            new Claim("userId", user.Id),
            new Claim("email", user.Email!)
        };

        foreach (string rol in roles!)
            claims.Add(new(ClaimTypes.Role, rol));

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
        SigningCredentials credenciales = new(key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor tokenDescription = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.DateTimeZoneInfo().Add(_jwtSettings.ExpireTime),
            SigningCredentials = credenciales
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }

    public string GetSessionUser()
    {
        string? username = _httpContextAccessor.HttpContext!.User?.Claims?
            .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

        return username!;
    }
}