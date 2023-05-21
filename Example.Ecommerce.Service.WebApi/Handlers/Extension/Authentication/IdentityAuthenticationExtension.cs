using Example.Ecommerce.Domain.Entities.Identity;
using Example.Ecommerce.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Authentication;

public static class IdentityAuthenticationExtension
{
    public static IServiceCollection AddIdentityAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        #region Identity service

        services.AddControllers(opt =>
        {
            AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });

        IdentityBuilder identityBuilder = services.AddIdentityCore<UserEntity>();
        identityBuilder = new(identityBuilder.UserType, identityBuilder.Services);

        identityBuilder.AddRoles<IdentityRole>().AddDefaultTokenProviders();
        identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<UserEntity, IdentityRole>>();

        identityBuilder.AddEntityFrameworkStores<EfApplicationDbContext>();
        identityBuilder.AddSignInManager<SignInManager<UserEntity>>();

        services.TryAddSingleton<ISystemClock, SystemClock>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                ValidateAudience = false,
                ValidateIssuer = false
            };
        });

        #endregion Identity service

        return services;
    }
}