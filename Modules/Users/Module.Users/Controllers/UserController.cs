using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Users.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using static Module.Users.Domain.PermissionIds;
using System;
using Msi.Web;
using Msi.Utilities.Filter;

namespace Modules.User.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {

        public UserController(
            IUnitOfWork unitOfWork,
            IEnumerable<IUnitOfWorkPipeline<Module.Users.Entities.User>> unitOfWorkPipeline)
        {
            var xx = unitOfWorkPipeline;
            var x = UnitOfWorkAccessor.Instance;
            var y = x == unitOfWork;
        }

        [HttpGet]
        [RequireAnyPermission(UserList, UserFullAccess)]
        public Task<IActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            return OkAsync(new GetUsersQuery(), pagingOptions, searchOptions) ;
        }

        [HttpGet("{id}")]
        [RequireAnyPermission(UserView, UserFullAccess)]
        public Task<IActionResult> Get(long id)
        {
            var query = new GetUserQuery { Id = id };
            return OkAsync(query);
        }

        [HttpPost]
        [RequireAnyPermission(UserCreate, UserFullAccess)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequireAnyPermission(UserUpdate, UserFullAccess)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        [RequireAnyPermission(UserDelete, UserFullAccess)]
        public Task<IActionResult> Delete([FromRoute] DeleteUserCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpPost("forgot-password")]
        public Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordCommand command)
        {
            return OkAsync(command);
        }

        [HttpPost("reset-password")]
        public Task<IActionResult> ResetPassword([FromBody]ResetPasswordCommand command)
        {
            return OkAsync(command);
        }

    }
}
