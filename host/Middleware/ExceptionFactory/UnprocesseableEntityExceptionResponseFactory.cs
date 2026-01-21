using System.Net;
using Shared_Kernal.Guards;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Model.Base;

namespace Estarta_Application.Middleware.ExceptionFactory
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
