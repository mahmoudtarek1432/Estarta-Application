using System.Net;
using System.ComponentModel.DataAnnotations;
using Shared_Kernal.Guards;
using Estarta_Application.Model.Base;
using Estarta_Application.Middleware.ExceptionFactory;
using Estarta_Application.Middleware.ExceptionFactory.Abstraction;

namespace EstartaApplicationServer.Middleware
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
