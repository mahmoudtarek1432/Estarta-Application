using Admin_Host.Middleware.ExceptionFactory.Abstraction;
using Admin_Host.Model.Base;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Admin_Host.Middleware.ExceptionFactory
{
    public class DefaultExceptionResponseFactory : IExceptionResponseFactory
    {
        public int StatusCode => (int)HttpStatusCode.InternalServerError;

        public object CreateResponse(Exception exception)
        {
            return ResponseBase.Error("An unexpected error occurred.");
        }
    }
}
