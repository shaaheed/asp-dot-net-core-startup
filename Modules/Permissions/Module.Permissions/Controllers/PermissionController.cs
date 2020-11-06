using Msi.Mediator.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Permissions.Domain;
using System.Threading.Tasks;
using Msi.Web;
using Module.Core;
using static Module.Permissions.Shared.PermissionIds;

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

        //[HttpPost]
        //[RequireAnyPermission(PermissionCreate, PermissionFullAccess)]
        //public async Task<ActionResult> Post([FromBody]CreatePermissionCommand command)
        //{
        //    var result = await _commandBus.SendAsync(command);
        //    return Created("abc", null);
        //}

        [HttpPut("{id}")]
        [RequireAnyPermission(PermissionUpdate, PermissionFullAccess)]
        public async Task<ActionResult> Put(long id, [FromBody]UpdatePermissionCommand command)
        {
            command.Id = id;
            var result = await _commandBus.SendAsync(command);
            return result.ToOkResult();
        }

        //[HttpDelete("{id}")]
        //[RequireAnyPermission(PermissionDelete, PermissionFullAccess)]
        //public async Task<ActionResult> Delete(long id)
        //{
        //    var command = new DeletePermissionCommand { Id = id };
        //    var result = await _commandBus.SendAsync(command);
        //    return NoContent();
        //}

        [HttpGet]
        [RequireAnyPermission(PermissionList, PermissionFullAccess)]
        public async Task<ActionResult> Gets()
        {
            var result = await _queryBus.SendAsync(new GetPermissionsQuery());
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequireAnyPermission(PermissionView, PermissionFullAccess)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _queryBus.SendAsync(new GetPermissionQuery { Id = id });
            return result.ToOkResult();
        }
    }
}
