using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GastosResidenciais.API.Middlewares
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var details = new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = details.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }
    }
}
