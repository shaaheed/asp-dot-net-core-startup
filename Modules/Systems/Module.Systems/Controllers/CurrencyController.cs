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
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            var query = new GetCurrenciesQuery
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

    }
}
