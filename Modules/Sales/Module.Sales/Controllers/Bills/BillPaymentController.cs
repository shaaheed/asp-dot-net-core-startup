using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Msi.Utilities.Filter;
using Module.Sales.Domain;

namespace Module.Sales.Controllers
{
    [Route("api/bills/{documentId}/payments")]
    [ApiController]
    [ETag]
    public class BillPaymentController : BaseController
    {
        [HttpPost]
        //[RequirePermission(InvoicePaymentCreate, InvoicePaymentManage)]
        public Task<IActionResult> Post(Guid documentId, [FromBody] CreateBillPaymentCommand command)
        {
            command.DocumentId = documentId;
            return OkAsync(command);
        }

        [HttpPut("{id}")]
        //[RequirePermission(InvoicePaymentUpdate, InvoicePaymentManage)]
        public Task<IActionResult> Put(Guid documentId, Guid id, [FromBody] UpdateBillPaymentCommand command)
        {
            command.DocumentId = documentId;
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
        public Task<IActionResult> Gets([FromRoute] GetBillPaymentsQuery query, [FromQuery] FilterOptions filterOptions)
        {
            query.FilterOptions = filterOptions;
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
