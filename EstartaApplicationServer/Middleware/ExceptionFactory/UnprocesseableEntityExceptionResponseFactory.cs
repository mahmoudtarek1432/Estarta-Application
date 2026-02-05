using Admin_Host.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using Shared_Kernal.Guards;
using System.Net;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public class UnprocesseableEntityExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.UnprocessableEntity;

        public object CreateResponse(Exception exception)
        {
            var validationEx = exception as UnProcessableEntityException;
            return new ResponseBase
            {
                Message = validationEx?.Message ?? "Entity Unprocessable."
            };
        }
    }
}
