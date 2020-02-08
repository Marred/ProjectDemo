using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectDemo.Application.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProjectDemo.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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
            catch (AggregateException ex)
            {
                if (ex.InnerException is EntityNotFoundException)
                    await HandleNotFoundException(context, ex.InnerException as EntityNotFoundException);
                throw ex;
            }
        }

        private Task HandleNotFoundException(HttpContext context, EntityNotFoundException ex)
        {
            var code = HttpStatusCode.NotFound;
            var result = JsonConvert.SerializeObject(new { ex.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

        private Task HandleValidationException(HttpContext context, ValidationException exception)
        {
            var code = HttpStatusCode.BadRequest;
            var result = JsonConvert.SerializeObject(exception.Errors);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
