using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Msi.Utilities.Filter;
using Module.Sales.Domain;

namespace Module.Sales.Controllers
{
    [Route("api/bills/{billId}/payments")]
    [ApiController]
    [ETag]
    public class BillPaymentController : BaseController
    {

        [HttpPost]
        //[RequirePermission(InvoicePaymentCreate, InvoicePaymentManage)]
        public async Task<IActionResult> Post(Guid billId, [FromBody] CreateBillPaymentCommand command)
        {
            command.BillId = billId;
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(InvoicePaymentUpdate, InvoicePaymentManage)]
        public Task<IActionResult> Put(Guid billId, Guid id, [FromBody] UpdateBillPaymentCommand command)
        {
            command.BillId = billId;
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(InvoicePaymentDelete, InvoicePaymentManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteBillPaymentCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(InvoicePaymentList, InvoicePaymentManage)]
        public Task<IActionResult> Gets([FromRoute] GetBillPaymentsQuery query, [FromQuery] SearchOptions searchOptions, [FromQuery] PagingOptions pagingOptions)
        {
            query.PagingOptions = pagingOptions;
            query.SearchOptions = searchOptions;
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(InvoicePaymentView, InvoicePaymentManage)]
        public Task<IActionResult> Get([FromRoute] GetBillPaymentQuery query)
        {
            return OkAsync(query);
        }
    }
}
