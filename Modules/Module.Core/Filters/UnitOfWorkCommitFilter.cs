using Microsoft.AspNetCore.Mvc.Filters;
using Msi.Extensions.Persistence.Abstractions;
using System.Threading.Tasks;

namespace Module.Core.Filters
{
    public class UnitOfWorkCommitFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var r = await next();
            var unitOfWork = r.HttpContext.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            await unitOfWork.CommitAsync();
        }
    }
}
