using Microsoft.AspNetCore.Mvc;
using Module.Systems.Attributes;
using Module.Users.Domain;
using System.Threading.Tasks;
using static Module.Users.Domain.PermissionIds;
using System;
using Msi.Web;
using Msi.Utilities.Filter;

namespace Modules.User.Controllers
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
        public Task<IActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            return OkAsync(new GetRolesQuery(), pagingOptions, searchOptions) ;
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
