using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Permissions.Data;
using Module.Permissions.Domain;
using System.Threading.Tasks;
using static Module.Permissions.Common.Permissions;

namespace Module.Permissions
{
    [Route("api/permissions")]
    [ApiController]
    [ETag]
    public class PermissionController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public PermissionController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        [RequirePermission(PermissionCreate, PermissionManage)]
        public async Task<ActionResult> Post([FromBody]CreatePermissionCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        [RequirePermission(PermissionUpdate, PermissionManage)]
        public async Task<ActionResult> Put(string id, [FromBody]UpdatePermissionCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [RequirePermission(PermissionDelete, PermissionManage)]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeletePermissionCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return NoContent();
        }

        [HttpGet]
        [RequirePermission(PermissionList, PermissionManage)]
        public async Task<ActionResult> Gets()
        {
            var permissions = await _queryBus.SendAsync(new GetPermissionsQuery());
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        [RequirePermission(PermissionView, PermissionManage)]
        public async Task<ActionResult> Get(string id)
        {
            var permission = await _queryBus.SendAsync(new GetPermissionQuery { Id = id });
            return Ok(permission);
        }
    }
}
