using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Authentication;

public static class IdentityAuthenticationExtension
{
    public static IServiceCollection AddIdentityAuthentication(this IServiceCollection services)
    {
        #region Identity service

        services.AddControllers(opt =>
        {
            AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });

        #endregion Identity service

        return services;
    }
}