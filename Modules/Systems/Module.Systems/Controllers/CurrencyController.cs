using Microsoft.AspNetCore.Mvc;
using Module.Systems.Domain;
using Msi.Utilities.Filter;
using Msi.Web;
using System.Threading.Tasks;

namespace Module.Systems.Controllers
{
    [Route("api/systems/currencies")]
    [ApiController]
    public class CurrencyController : BaseController
    {

        [HttpGet]
        //[RequirePermission(InvoiceList, InvoiceManage)]
        public Task<IActionResult> Gets([FromQuery] SearchOptions searchOptions, [FromQuery] PagingOptions pagingOptions)
        {
            var query = new GetCurrenciesQuery
            {
                PagingOptions = pagingOptions,
                SearchOptions = searchOptions
            };
            return OkAsync(query);
        }

    }
}
