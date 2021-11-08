using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Msi.Utilities.Filter;
using Module.Integrations.Domain;

namespace Module.Sales.Controllers
{
    [Route("api/integrations/providers")]
    [ApiController]
    [ETag]
    public class ProviderController : BaseController
    {

        [HttpPut("{id}")]
        //[RequirePermission(InvoiceUpdate, InvoiceManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateProviderCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpGet]
        //[RequirePermission(InvoiceList, InvoiceManage)]
        public Task<IActionResult> Gets([FromQuery]FilterOptions filterOptions)
        {
            var query = new GetProvidersQuery
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }
    }
}
