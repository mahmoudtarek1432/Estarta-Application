using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Estarta_Application.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;

namespace EstartaApplicationServer.Middleware
{
    public class NotFoundExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.NotFound;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as NotFoundException;
            return new ErrorResponse
            {
                Error = validationEx?.Message ?? "Resource Not Found."
            };
        }
    }
}
