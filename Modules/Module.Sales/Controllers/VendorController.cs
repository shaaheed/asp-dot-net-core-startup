using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Sales.Domain.Vendors;
using System.Threading.Tasks;
using static Module.Sales.Common.Permissions;

namespace Module.Sales.Controllers
{
    [Route("api/vendors")]
    [ApiController]
    [ETag]
    public class VendorController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public VendorController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        [RequirePermission(VendorCreate, VendorManage)]
        public async Task<ActionResult> Post([FromBody]CreateVendorCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        [RequirePermission(VendorUpdate, VendorManage)]
        public async Task<ActionResult> Put(long id, [FromBody]UpdateVendorCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [RequirePermission(VendorDelete, VendorManage)]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteVendorCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return NoContent();
        }

        [HttpGet]
        [RequirePermission(VendorList, VendorManage)]
        public async Task<ActionResult> Gets()
        {
            var products = await _queryBus.SendAsync(new GetVendorsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        [RequirePermission(VendorView, VendorManage)]
        public async Task<ActionResult> Get(long id)
        {
            var product = await _queryBus.SendAsync(new GetVendorQuery { Id = id });
            return Ok(product);
        }
    }
}
