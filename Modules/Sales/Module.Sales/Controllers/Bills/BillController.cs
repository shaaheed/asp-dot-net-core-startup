using Microsoft.AspNetCore.Mvc;
using Module.Sales.Domain;
using System.Threading.Tasks;
using static Module.Sales.Common.Permissions;
using Msi.Web;
using System;
using Msi.Utilities.Filter;

namespace Module.Sales.Controllers
{
    [Route("api/bills")]
    [ApiController]
    [ETag]
    public class BillController : BaseController
    {

        [HttpPost]
        //[RequirePermission(InvoiceCreate, InvoiceManage)]
        public async Task<IActionResult> Post([FromBody] CreateBillCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(InvoiceUpdate, InvoiceManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateBillCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(InvoiceDelete, InvoiceManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteBillCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(InvoiceList, InvoiceManage)]
        public Task<IActionResult> Gets([FromQuery]FilterOptions filterOptions)
        {
            var query = new GetBillsQuery
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

        [HttpGet("create-info")]
        //[RequirePermission(InvoiceList, InvoiceManage)]
        public Task<IActionResult> GetCreateInfo()
        {
            return OkAsync(new GetBillCreateInfoQuery());
        }

        [HttpGet("{id}")]
        //[RequirePermission(InvoiceView, InvoiceManage)]
        public Task<IActionResult> Get([FromRoute] GetBillQuery query)
        {
            return OkAsync(query);
        }
    }
}
