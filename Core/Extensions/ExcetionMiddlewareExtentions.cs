using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class ExcetionMiddlewareExtentions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}