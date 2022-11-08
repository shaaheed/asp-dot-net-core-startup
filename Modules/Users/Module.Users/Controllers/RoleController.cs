using Microsoft.AspNetCore.Mvc;
using Module.Systems.Attributes;
using Module.Accounts.Domain;
using static Module.Accounts.Domain.PermissionIds;
using Msi.Web;
using Msi.Utilities.Filter;

namespace Modules.Accounts.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : BaseController
    {

        public RoleController()
        {
        }

        [HttpGet]
        [RequireAnyPermission(RoleList, RoleFullAccess)]
        public Task<IActionResult> List([FromQuery] FilterOptions filterOptions)
        {
            return OkAsync(new GetRolesQuery(), filterOptions) ;
        }

        [HttpGet("{id}")]
        [RequireAnyPermission(RoleView, RoleFullAccess)]
        public Task<IActionResult> Get(Guid id)
        {
            var query = new GetRoleQuery { Id = id };
            return OkAsync(query);
        }

        [HttpPost]
        [RequireAnyPermission(RoleCreate, RoleFullAccess)]
        public async Task<IActionResult> Post([FromBody] CreateRoleCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequireAnyPermission(RoleUpdate, RoleFullAccess)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateRoleCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        [RequireAnyPermission(RoleDelete, RoleFullAccess)]
        public Task<IActionResult> Delete([FromRoute] DeleteRoleCommand command)
        {
            return DeleteAsync(command);
        }

    }
}
