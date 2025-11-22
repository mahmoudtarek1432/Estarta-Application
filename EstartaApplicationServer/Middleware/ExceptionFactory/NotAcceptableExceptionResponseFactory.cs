using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Estarta_Application.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;

namespace EstartaApplicationServer.Middleware
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
