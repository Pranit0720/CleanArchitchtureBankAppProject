using BankApp.Application.Exceptions;
using System.Net;

namespace BankApp.API.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
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
            catch (Exception ex)
            {
                await HandleExceptionsAsync(httpContext, ex);
            }
        }
        private static async Task<Task> HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                //case AccountNotFoundException AccNotFound:
                //    statusCode = HttpStatusCode.NotFound;
                //    break;
                case InsufficientBalance insuffBal:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case BadRequestException badReq:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            httpContext.Response.StatusCode = (int)statusCode;
            var response = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message
            };
            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
