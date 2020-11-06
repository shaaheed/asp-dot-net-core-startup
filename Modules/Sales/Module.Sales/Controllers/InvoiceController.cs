//using Msi.Mediator.Abstractions;
//using Core.Web.Filters;
//using Microsoft.AspNetCore.Mvc;
//using Module.Core.Attributes;
//using Module.Sales.Domain.Invoices;
//using System.Threading.Tasks;
//using static Module.Sales.Common.Permissions;

//namespace Module.Sales.Controllers
//{
//    [Route("api/invoices")]
//    [ApiController]
//    [ETag]
//    public class InvoiceController : ControllerBase
//    {

//        private readonly ICommandBus _commandBus;
//        private readonly IQueryBus _queryBus;

//        public InvoiceController(
//            ICommandBus commandBus,
//            IQueryBus queryBus)
//        {
//            _commandBus = commandBus;
//            _queryBus = queryBus;
//        }

//        [HttpPost]
//        [RequirePermission(InvoiceCreate, InvoiceManage)]
//        public async Task<ActionResult> Post([FromBody]CreateInvoiceCommand command)
//        {
//            var r = await _commandBus.SendAsync(command);
//            return Created("abc", null);
//        }

//        [HttpPut("{id}")]
//        [RequirePermission(InvoiceUpdate, InvoiceManage)]
//        public async Task<ActionResult> Put(long id, [FromBody]UpdateInvoiceCommand command)
//        {
//            command.Id = id;
//            var r = await _commandBus.SendAsync(command);
//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        [RequirePermission(InvoiceDelete, InvoiceManage)]
//        public async Task<ActionResult> Delete(long id)
//        {
//            var command = new DeleteInvoiceCommand { Id = id };
//            var r = await _commandBus.SendAsync(command);
//            return NoContent();
//        }

//        [HttpGet]
//        [RequirePermission(InvoiceList, InvoiceManage)]
//        public async Task<ActionResult> Gets()
//        {
//            var products = await _queryBus.SendAsync(new GetInvoicesQuery());
//            return Ok(products);
//        }

//        [HttpGet("{id}")]
//        [RequirePermission(InvoiceView, InvoiceManage)]
//        public async Task<ActionResult> Get(long id)
//        {
//            var product = await _queryBus.SendAsync(new GetInvoiceQuery { Id = id });
//            return Ok(product);
//        }
//    }
//}
