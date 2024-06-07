using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

namespace API.WebApiService.Interceptors;

public class JwtTokenFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext actionContext)
    {
        var token = actionContext.HttpContext.Request.Headers["authorization"].FirstOrDefault() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(token) == false)
        {
            var jwtTokenService = actionContext.HttpContext.RequestServices.GetRequiredService<IJwtTokenService>();
            
            if (jwtTokenService is not null)
                jwtTokenService.Parse(token, CancellationToken.None).RunSynchronously();
        }

        base.OnActionExecuting(actionContext);
    }
}
