using EazyQuiz.Web.Api.Middlewares;

namespace EazyQuiz.Web.Api;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseEazyQuizMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<RoleCheckMiddleware>();
        return builder;
    }
}
