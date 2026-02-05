using Admin_Host.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using System.Net;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class DefaultExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.InternalServerError;

        public object CreateResponse(Exception exception)
        {
            return new ResponseBase
            {
                Message = "An unexpected error occurred.",
            };
        }
    }
}
