using TestWebAPI.Model;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TestWebAPI.ExceptionHandler
{
    public class GlobalExceptionHandler() : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            var errorResponse = new ErrorResponse();

            switch (exception)
            {
                case BadHttpRequestException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = exception.Message;
                    break;

                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal Server Error";
                    break;
            }

            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext
                .Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }

}
