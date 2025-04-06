using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommonLib.Response;
using CommonLib.Response.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Refit;

namespace CommonLib.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    /// <summary>
    /// Использовать глобальный фильтр ошибок
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        => builder.UseMiddleware<ExceptionMiddleware>();
}

public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;
    
    private static JsonSerializerOptions _jsonSerializerOptions = new()
    {
        Converters = { new JsonStringEnumMemberConverter() },
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };


    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException exception)
        {
            var content = await exception.GetContentAsAsync<Dictionary<String, String>>();
            var statusMessageContent = content?.GetValueOrDefault("statusMessage");
            context.Response.StatusCode = (int)exception.StatusCode;
            var response = new BaseResponse()
            {
                StatusMessage = statusMessageContent ?? exception.Message,
                Status = ResponseStatus.Error
            };
            var msg = $"{exception.GetType()}\n {exception.Message}\n {exception.InnerException?.Message}\n {exception.StackTrace}";
            _logger.LogError(msg);

            var jsonString = JsonSerializer.Serialize(response, _jsonSerializerOptions);
            await context.Response.WriteAsync(jsonString);
        }
        catch (ExceptionResponse exception)
        {
            context.Response.StatusCode = (int)(exception.HttpStatusCode ?? HttpStatusCode.InternalServerError);
            
            var response = new BaseResponse()
            {
                Status = exception.Status,
                StatusMessage = exception.StatusMessage
            };
            _logger.LogError(
                "(ResponseException:Status:{Status}, StatusMessage:{StatusMessage}",
                response.Status, response.StatusMessage);
            
            var jsonString = JsonSerializer.Serialize(response, _jsonSerializerOptions);
            await context.Response.WriteAsync(jsonString);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var msg = $"{exception.GetType()}\n {exception.Message}\n {exception.InnerException?.Message}\n {exception.StackTrace}";
            var response = new BaseResponse()
            {
                Status = ResponseStatus.Error,
                StatusMessage = msg
            };
            _logger.LogError(msg);
            
            var jsonString = JsonSerializer.Serialize(response, _jsonSerializerOptions);
            await context.Response.WriteAsync(jsonString);
        }
    }
}