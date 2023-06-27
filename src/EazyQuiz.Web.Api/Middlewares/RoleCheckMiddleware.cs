using EazyQuiz.Web.Api.Attributes;
using System.Security.Authentication;
using System.Security.Claims;

namespace EazyQuiz.Web.Api.Middlewares;

public class RoleCheckMiddleware
{
    private readonly RequestDelegate _next;
    
    public RoleCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.GetEndpoint()?.Metadata.GetMetadata<AdminOnlyAttribute>() is not null)
        {
            string? role = context.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            if (role != "Admin")
            {
                throw new AuthenticationException("You do not have permission");
            }
        }
        
        await _next.Invoke(context);
    }
}
