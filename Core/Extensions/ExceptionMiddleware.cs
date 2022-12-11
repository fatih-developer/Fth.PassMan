using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            

            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExteptionAsync(httpContext, e);
            }
        }

        private Task HandleExteptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            

            string message = "Internal Server Error";
            if (exception.GetType()==typeof(ValidationException))
            {
                message = exception.Message;
            }

            return httpContext.Response.WriteAsync(new ErrorDetail
            {
                StatusCode = httpContext.Response.StatusCode, 
                Message = message,
                
                
            }.ToString());
        }
    }

}