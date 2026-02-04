using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Estarta_Application.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;

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
