using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.Ecommerce.Service.WebApi.Services.AntiforgeryCookie;

public class AntiforgeryCookieResultFilter : ResultFilterAttribute
{
    private readonly IAntiforgery _antiforgery;

    public AntiforgeryCookieResultFilter(IAntiforgery antiforgery) => _antiforgery = antiforgery;

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is not ViewResult) return;

        AntiforgeryTokenSet tokens = _antiforgery.GetAndStoreTokens(context.HttpContext);
        context.HttpContext.Response.Cookies.Append(
            "XSRF-TOKEN", tokens.RequestToken!, new CookieOptions() { HttpOnly = false });
    }
}
