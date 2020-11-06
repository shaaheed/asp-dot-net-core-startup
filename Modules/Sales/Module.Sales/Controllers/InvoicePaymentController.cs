//using Msi.Mediator.Abstractions;
//using Core.Web.Filters;
//using Microsoft.AspNetCore.Mvc;
//using Module.Core.Attributes;
//using Module.Sales.Domain.InvoicePayments;
//using System.Threading.Tasks;
//using static Module.Sales.Common.Permissions;

//namespace Module.Sales.Controllers
//{
//    [Route("api/invoices/{invoiceId}/payments")]
//    [ApiController]
//    [ETag]
//    public class InvoicePaymentController : ControllerBase
//    {

//        private readonly ICommandBus _commandBus;
//        private readonly IQueryBus _queryBus;

//        public InvoicePaymentController(
//            ICommandBus commandBus,
//            IQueryBus queryBus)
//        {
//            _commandBus = commandBus;
//            _queryBus = queryBus;
//        }

//        [HttpPost]
//        [RequirePermission(InvoicePaymentCreate, InvoicePaymentManage)]
//        public async Task<ActionResult> Post([FromBody]CreateInvoicePaymentCommand command)
//        {
//            var r = await _commandBus.SendAsync(command);
//            return Created("abc", null);
//        }

//        [HttpPut("{id}")]
//        [RequirePermission(InvoicePaymentUpdate, InvoicePaymentManage)]
//        public async Task<ActionResult> Put(long id, [FromBody]UpdateInvoicePaymentCommand command)
//        {
//            command.Id = id;
//            var r = await _commandBus.SendAsync(command);
//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        [RequirePermission(InvoicePaymentDelete, InvoicePaymentManage)]
//        public async Task<ActionResult> Delete(long id)
//        {
//            var command = new DeleteInvoicePaymentCommand { Id = id };
//            var r = await _commandBus.SendAsync(command);
//            return NoContent();
//        }

//        [HttpGet]
//        [RequirePermission(InvoicePaymentList, InvoicePaymentManage)]
//        public async Task<ActionResult> Gets(long invoiceId)
//        {
//            var query = new GetInvoicePaymentsQuery { InvoiceId = invoiceId };
//            var products = await _queryBus.SendAsync(query);
//            return Ok(products);
//        }

//        [HttpGet("{id}")]
//        [RequirePermission(InvoicePaymentView, InvoicePaymentManage)]
//        public async Task<ActionResult> Get(long id)
//        {
//            var product = await _queryBus.SendAsync(new GetInvoicePaymentQuery { Id = id });
//            return Ok(product);
//        }
//    }
//}
