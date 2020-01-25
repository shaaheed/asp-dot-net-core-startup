using Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Module.Core.Exceptions
{
    public class ExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessExceptionBase)
            {
                var exception = (BusinessExceptionBase)context.Exception;
                context.HttpContext.Response.StatusCode = exception.Status;
                context.Result = new ObjectResult(new
                {
                    Status = exception.Status,
                    Message = exception.Message
                });
            }
        }
    }
}
