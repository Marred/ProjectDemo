using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProjectDemo.WebAPI.Middlewares
{
    public class FluentValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public FluentValidationExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationException(context, ex);
            }
        }

        private Task HandleValidationException(HttpContext context, ValidationException exception)
        {
            var code = HttpStatusCode.UnprocessableEntity;
            var result = JsonConvert.SerializeObject(exception.Errors);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseFluentValidationExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FluentValidationExceptionHandlerMiddleware>();
        }
    }
}
