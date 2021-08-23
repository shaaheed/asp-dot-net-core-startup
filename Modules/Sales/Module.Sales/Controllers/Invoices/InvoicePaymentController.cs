using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Msi.Utilities.Filter;
using Module.Sales.Domain;

namespace Module.Sales.Controllers
{
    [Route("api/invoices/{invoiceId}/payments")]
    [ApiController]
    [ETag]
    public class InvoicePaymentController : BaseController
    {

        [HttpPost]
        //[RequirePermission(InvoicePaymentCreate, InvoicePaymentManage)]
        public async Task<IActionResult> Post(Guid invoiceId, [FromBody] CreateInvoicePaymentCommand command)
        {
            command.InvoiceId = invoiceId;
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(InvoicePaymentUpdate, InvoicePaymentManage)]
        public Task<IActionResult> Put(Guid invoiceId, Guid id, [FromBody] UpdateInvoicePaymentCommand command)
        {
            command.InvoiceId = invoiceId;
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(InvoicePaymentDelete, InvoicePaymentManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteInvoicePaymentCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(InvoicePaymentList, InvoicePaymentManage)]
        public Task<IActionResult> Gets([FromRoute] GetInvoicePaymentsQuery query, [FromQuery] FilterOptions filterOptions)
        {
            query.FilterOptions = filterOptions;
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(InvoicePaymentView, InvoicePaymentManage)]
        public Task<IActionResult> Get([FromRoute] GetInvoicePaymentQuery query)
        {
            return OkAsync(query);
        }
    }
}
