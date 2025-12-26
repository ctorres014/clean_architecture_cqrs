using GloboTicket.TicketManagment.Application.Exceptions;
using GloboTicket.TicketManagment.Application.Exepctions;
using System.Net;
using System.Text.Json;

namespace GloboTicket.TicketManagment.WebApi.Middleware
{
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
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                default:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;
            if (!string.IsNullOrEmpty(result))
            {
                result = JsonSerializer.Serialize( new { error = exception.Message });
            }
            return context.Response.WriteAsync(result);
        }
    }
}
