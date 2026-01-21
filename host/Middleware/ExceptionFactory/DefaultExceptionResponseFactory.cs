using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Model.Base;
using System.Net;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class DefaultExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.InternalServerError;

        public object CreateResponse(Exception exception)
        {
            return new ErrorResponse
            {
                Error = "An unexpected error occurred.",
            };
        }
    }
}
