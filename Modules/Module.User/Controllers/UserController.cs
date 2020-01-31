using Comment.Application.Attributes;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Users.Domain;
using System.Threading.Tasks;
using static Comment.Application.Constants.PermissionConstants.Operations;
using static Comment.Application.Constants.PermissionConstants.Permission;

namespace Modules.User.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/users")]
    [ApiController]
    [Resource(USERS)]
    public class UserController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public UserController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet]
        //[AuthorizeResource(Operation = READ_LIST)]
        [Authorize]
        public async Task<ActionResult> Get()
        {
            var query = new GetUsersQuery();
            var r = await _queryBus.SendAsync(query);
            return Ok(r);
        }

        [HttpGet("{id}")]
        [AuthorizeResource(Operation = READ_DETAILS)]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [AuthorizeResource(Operation = CREATE)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Ok(r);
        }

        [HttpPut("{id}")]
        [AuthorizeResource(Operation = EDIT)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var result = await _commandBus.SendAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [AuthorizeResource(Operation = DELETE)]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command)
        {
            await _commandBus.SendAsync(command);
            return NoContent();
        }

    }
}
