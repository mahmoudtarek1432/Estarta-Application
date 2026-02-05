using Admin_Host.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Guards;
using System.Net;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class NotFoundExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.NotFound;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as NotFoundException;
            return new ResponseBase
            {
                Message = validationEx?.Message ?? "Resource Not Found."
            };
        }
    }
}
