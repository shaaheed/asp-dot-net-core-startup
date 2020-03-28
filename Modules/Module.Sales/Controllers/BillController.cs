using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Sales.Domain.Bills;
using System.Threading.Tasks;
using static Module.Sales.Common.Permissions;

namespace Module.Sales.Controllers
{
    [Route("api/bills")]
    [ApiController]
    [ETag]
    public class BillController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public BillController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        [RequirePermission(BillCreate, BillManage)]
        public async Task<ActionResult> Post([FromBody]CreateBillCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        [RequirePermission(BillUpdate, BillManage)]
        public async Task<ActionResult> Put(long id, [FromBody]UpdateBillCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [RequirePermission(BillDelete, BillManage)]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteBillCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return NoContent();
        }

        [HttpGet]
        [RequirePermission(BillList, BillManage)]
        public async Task<ActionResult> Gets()
        {
            var bills = await _queryBus.SendAsync(new GetBillsQuery());
            return Ok(bills);
        }

        [HttpGet("{id}")]
        [RequirePermission(BillView, BillManage)]
        public async Task<ActionResult> Get(long id)
        {
            var bill = await _queryBus.SendAsync(new GetBillQuery { Id = id });
            return Ok(bill);
        }
    }
}
