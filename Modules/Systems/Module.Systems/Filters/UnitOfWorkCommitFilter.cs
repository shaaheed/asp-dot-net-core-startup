using Microsoft.AspNetCore.Mvc.Filters;
using Msi.Data.Abstractions;
using System.Threading.Tasks;

namespace Module.Systems.Filters
{
    public class UnitOfWorkCommitFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _next = await next();
            if (_next.Exception == null && context.HttpContext.Request.Method != "GET")
            {
                var unitOfWork = _next.HttpContext.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
                await unitOfWork.CommitAsync();
            }
        }
    }
}
