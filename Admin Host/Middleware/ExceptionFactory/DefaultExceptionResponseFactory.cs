using Admin_Host.Middleware.ExceptionFactory.Abstraction;
using Admin_Host.Model.Base;
using System.Net;

namespace Admin_Host.Middleware.ExceptionFactory
{
    public class DefaultExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.InternalServerError;

        public object CreateResponse(Exception exception)
        {
            return new ResponseBase
            {
                Message = "An unexpected error occurred.",
            };
        }
    }
}
