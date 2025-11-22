using Estarta_Application.Middleware.ExceptionFactory.Abstraction;
using EstartaApplicationServer.Middleware;
using Shared_Kernal.Guards;
using System.ComponentModel.DataAnnotations;

namespace Estarta_Application.Middleware.ExceptionFactory
{
    public static class ExceptionResponseFactory
    {
        public static IExceptionResponseFactory GetFactory(Exception exception)
        {
            if (exception is BusinessLogicException)
                return new BusinessLogicExceptionResponseFactory();
            if (exception is NotFoundException)
                return new NotFoundExceptionResponseFactory();
            if (exception is NotFoundException)
                return new NotFoundExceptionResponseFactory();
            if (exception is UnProcessableEntityException)
                return new UnprocesseableEntityExceptionResponseFactory();

            // Add more exception type checks here if needed

            return new DefaultExceptionResponseFactory();
        }
    }
}
