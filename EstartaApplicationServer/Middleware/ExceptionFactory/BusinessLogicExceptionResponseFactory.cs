using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Model.Base;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class BusinessLogicExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.BadRequest;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as BusinessLogicException;
            return new ErrorResponse
            {
                Error = validationEx?.Message ?? "Invalid input."
            };
        }
    }
}
