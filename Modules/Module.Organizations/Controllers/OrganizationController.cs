using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Organizations.Domain;
using System.Threading.Tasks;
using static Module.Organizations.Common.Permissions;

namespace Module.Organizations
{
    [Route("api/organizations")]
    [ApiController]
    [ETag]
    public class OrganizationController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public OrganizationController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        [RequirePermission(OrganizationCreate, OrganizationManage)]
        public async Task<ActionResult> Post([FromBody]CreateOrganizationCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        [RequirePermission(OrganizationUpdate, OrganizationManage)]
        public async Task<ActionResult> Put(long id, [FromBody]UpdateOrganizationCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [RequirePermission(OrganizationDelete, OrganizationManage)]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteOrganizationCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return NoContent();
        }

        [HttpGet]
        [RequirePermission(OrganizationList, OrganizationManage)]
        public async Task<ActionResult> Gets()
        {
            var products = await _queryBus.SendAsync(new GetOrganizationsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        [RequirePermission(OrganizationView, OrganizationManage)]
        public async Task<ActionResult> Get(long id)
        {
            var product = await _queryBus.SendAsync(new GetOrganizationQuery { Id = id });
            return Ok(product);
        }
    }
}
