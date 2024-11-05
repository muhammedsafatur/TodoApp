using Core.Entities;
using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ReturnModel<List<string>> Errors = new ReturnModel<List<string>>();

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            if (exception.GetType() == typeof(NotFoundException))
            {
                httpContext.Response.StatusCode = 404;
                Errors.Success = false;
                Errors.Message = exception.Message;
                Errors.Status = 404;

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors,jsonOptions));

            }
            if (exception is ValidationException validationEx)
            {
                httpContext.Response.StatusCode = 400;
                Errors.Data = new List<string> { validationEx.Message }; 
                Errors.Success = false;
                Errors.Message = "Validation failed.";
                Errors.Status = 400;

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors, jsonOptions));
                return true; 
            }


            if (exception.GetType() == typeof(BusinessException))
            {
                httpContext.Response.StatusCode = 400;
                Errors.Success = false;
                Errors.Message = exception.Message;
                Errors.Status = 400;

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors,jsonOptions));

            }

            Errors.Status = 500;
            Errors.Success = false;
            Errors.Message = exception.Message;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors,jsonOptions));

            return true;
        }
    }
}
