//using Msi.Mediator.Abstractions;
//using Core.Web.Filters;
//using Microsoft.AspNetCore.Mvc;
//using Module.Core.Attributes;
//using Module.Sales.Domain.Customers;
//using System.Threading.Tasks;
//using static Module.Sales.Common.Permissions;

//namespace Module.Sales.Controllers
//{
//    [Route("api/customers")]
//    [ApiController]
//    [ETag]
//    public class CustomerController : ControllerBase
//    {

//        private readonly ICommandBus _commandBus;
//        private readonly IQueryBus _queryBus;

//        public CustomerController(
//            ICommandBus commandBus,
//            IQueryBus queryBus)
//        {
//            _commandBus = commandBus;
//            _queryBus = queryBus;
//        }

//        [HttpPost]
//        [RequirePermission(CustomerCreate, CustomerManage)]
//        public async Task<ActionResult> Post([FromBody]CreateCustomerCommand command)
//        {
//            var r = await _commandBus.SendAsync(command);
//            return Created("abc", null);
//        }

//        [HttpPut("{id}")]
//        [RequirePermission(CustomerUpdate, CustomerManage)]
//        public async Task<ActionResult> Put(long id, [FromBody]UpdateCustomerCommand command)
//        {
//            command.Id = id;
//            var r = await _commandBus.SendAsync(command);
//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        [RequirePermission(CustomerDelete, CustomerManage)]
//        public async Task<ActionResult> Delete(long id)
//        {
//            var command = new DeleteCustomerCommand { Id = id };
//            var r = await _commandBus.SendAsync(command);
//            return NoContent();
//        }

//        [HttpGet]
//        [RequirePermission(CustomerList, CustomerManage)]
//        public async Task<ActionResult> Gets()
//        {
//            var products = await _queryBus.SendAsync(new GetCustomersQuery());
//            return Ok(products);
//        }

//        [HttpGet("{id}")]
//        [RequirePermission(CustomerView, CustomerManage)]
//        public async Task<ActionResult> Get(long id)
//        {
//            var product = await _queryBus.SendAsync(new GetCustomerQuery { Id = id });
//            return Ok(product);
//        }
//    }
//}
