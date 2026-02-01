using System.Net;
using Shared_Kernal.Guards;
using Admin_Host.Middleware.ExceptionFactory.Abstraction;
using Admin_Host.Model.Base;

namespace Admin_Host.Middleware.ExceptionFactory
{
    public class UnprocesseableEntityExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.UnprocessableEntity;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as UnProcessableEntityException;
            return new ErrorResponse
            {
                Error = validationEx?.Message ?? "Entity Unprocessable."
            };
        }
    }
}
