using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Model.Base;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class NotAcceptableExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.NotAcceptable;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as NotAcceptableException;
            return new ErrorResponse
            {
                Error = validationEx?.Message ?? "Not Acceptable Request."
            };
        }
    }
}
