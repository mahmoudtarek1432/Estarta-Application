using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Admin_Host.Middleware.ExceptionFactory.Abstraction;
using Admin_Host.Model.Base;

namespace Admin_Host.Middleware.ExceptionFactory
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
