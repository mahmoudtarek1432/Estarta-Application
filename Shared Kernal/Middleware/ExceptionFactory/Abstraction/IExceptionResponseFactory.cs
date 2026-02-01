using Microsoft.AspNetCore.Http;

namespace Estarta_Application.Middleware.ExceptionFactory.Abstraction
{
    public interface IExceptionResponseFactory
    {
        int StatusCode { get; }
        object CreateResponse(Exception exception);
    }
}
