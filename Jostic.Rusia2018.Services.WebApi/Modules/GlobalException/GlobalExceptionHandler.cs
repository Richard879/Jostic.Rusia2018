using Jostic.Rusia2018.Application.UseCases.Common.Exceptions;
using Jostic.Rusia2018.Transversal.Common;
using System.Net;
using System.Text.Json;

namespace Jostic.Rusia2018.Services.WebApi.Modules.GlobalException
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationExceptionCustom ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body,
                    new Response<Object> { Message = "Errores de validación", Errors = ex.Errors! });
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                _logger.LogError($"Exception Details: { message }" );
                var response = new Response<Object>()
                {
                    Message = message
                };
                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
        }
    }
}