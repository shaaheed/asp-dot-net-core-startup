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
            var unitOfWork = _next.HttpContext.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            await unitOfWork.CommitAsync();
        }
    }
}
