using Admin_Host.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Guards;
using System.Net;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class BusinessLogicExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.BadRequest;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as BusinessLogicException;
            return new ResponseBase
            {
                Message = validationEx?.Message ?? "Invalid input."
            };
        }
    }
}
