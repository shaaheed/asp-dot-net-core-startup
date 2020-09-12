using Comment.Application.Attributes;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Users.Common;
using Module.Users.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Modules.User.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public UserController(
            ICommandBus commandBus,
            IQueryBus queryBus,
            IUnitOfWork unitOfWork)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            var x = UnitOfWorkAccessor.Instance;
            var y = x == unitOfWork;
        }

        [HttpGet]
        [RequirePermission(Permissions.UserList)]
        //[Authorize]
        public async Task<ActionResult> Gets()
        {
            //var query = new GetUsersQuery();
            //var r = await _queryBus.SendAsync(query);
            //return Ok(r);

            await new Module.Users.Entities.User().SaveAsync();
            return Ok(new List<string> { "value1", "value2" });
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.UserView)]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [RequirePermission(Permissions.UserCreate)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Ok(r);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.UserUpdate)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var result = await _commandBus.SendAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.UserDelete)]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command)
        {
            await _commandBus.SendAsync(command);
            return NoContent();
        }

    }
}
