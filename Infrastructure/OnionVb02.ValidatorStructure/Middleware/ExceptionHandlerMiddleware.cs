using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using OnionVb02.ValidatorStructure.Exceptions;

namespace OnionVb02.ValidatorStructure.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new ErrorResponse();

        switch (exception)
        {
            // Validation hatası
            case ValidationException validationEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = "Doğrulama hatası oluştu.";
                response.Errors = validationEx.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();
                break;

            // Kayıt bulunamadı
            case NotFoundException notFoundEx:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = notFoundEx.Message;
                break;

            // İş kuralı hatası
            case BusinessException businessEx:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = businessEx.Message;
                break;

            // Yetkilendirme hatası
            case UnauthorizedException unauthorizedEx:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.Message = unauthorizedEx.Message;
                break;

            // Çakışma hatası
            case ConflictException conflictEx:
                response.StatusCode = (int)HttpStatusCode.Conflict;
                response.Message = conflictEx.Message;
                break;

            // Beklenmeyen hata
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Beklenmeyen bir hata oluştu.";
                response.Errors.Add(exception.Message);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode;

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
    }
}

