using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Admin_Host.Middleware.ExceptionFactory.Abstraction;
using Admin_Host.Model.Base;

namespace Admin_Host.Middleware.ExceptionFactory
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
