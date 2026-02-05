using Admin_Host.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Guards;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class NotAcceptableExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.NotAcceptable;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as NotAcceptableException;
            return new ResponseBase
            {
                Message = validationEx?.Message ?? "Not Acceptable Request."
            };
        }
    }
}
