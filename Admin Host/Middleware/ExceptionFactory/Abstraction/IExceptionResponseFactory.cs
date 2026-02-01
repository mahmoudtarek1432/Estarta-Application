using Microsoft.AspNetCore.Http;

namespace Admin_Host.Middleware.ExceptionFactory.Abstraction
{
    public interface IExceptionResponseFactory
    {
        int StatusCode { get; }
        object CreateResponse(Exception exception);
    }
}
