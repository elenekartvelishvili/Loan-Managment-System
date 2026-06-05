using Microsoft.AspNetCore.Diagnostics;

namespace Loan_Managment_System.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            switch (exception) {

                case KeyNotFoundException:
                    httpContext.Response.StatusCode = 404; break;
                case ArgumentException:
                    httpContext.Response.StatusCode = 400; break;
                default:
                    httpContext.Response.StatusCode = 500; break;


            }
            await httpContext.Response.WriteAsJsonAsync(new
            {

                Message = exception.Message
            }, cancellationToken);

            return true;

        }
    }
}