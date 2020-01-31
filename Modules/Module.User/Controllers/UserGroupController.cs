//using System.Threading.Tasks;
//using Application.UserGroups.Commands;
//using Application.UserGroups.Queries;
//using Comment.Application.Attributes;
//using Core.Application.Commands;
//using Core.Application.Queries;
//using Microsoft.AspNetCore.Mvc;
//using static Comment.Application.Constants.PermissionConstants.Operations;
//using static Comment.Application.Constants.PermissionConstants.Permission;

//namespace Module.Comment.Controllers
//{
//    //[ApiVersion("v1")]
//    [Route("api/users")]
//    [ApiController]
//    [Resource(USERS_GROUPS)]
//    public class UserGroupController : ControllerBase
//    {

//        private readonly ICommandBus _commandBus;
//        private readonly IQueryBus _queryBus;

//        public UserGroupController(
//            ICommandBus commandBus,
//            IQueryBus queryBus)
//        {
//            _commandBus = commandBus;
//            _queryBus = queryBus;
//        }

//        [HttpGet("groups")]
//        [AuthorizeResource(Operation = READ_LIST)]
//        public async Task<ActionResult> Get()
//        {
//            var query = new GetUserGroupsQuery();
//            var r = await _queryBus.SendAsync(query);
//            return Ok(r);
//        }

//        [HttpPost("groups")]
//        [AuthorizeResource(Operation = CREATE)]
//        public async Task<IActionResult> Post([FromBody] CreateUserGroupCommand command)
//        {
//            var r = await _commandBus.SendAsync(command);
//            return Ok(r);
//        }

//        [HttpDelete("groups/{id}")]
//        [AuthorizeResource(Operation = DELETE)]
//        public async Task<IActionResult> Delete([FromRoute] DeleteUserGroupCommand command)
//        {
//            await _commandBus.SendAsync(command);
//            return NoContent();
//        }

//        [HttpPut("groups/{id}")]
//        [AuthorizeResource(Operation = EDIT)]
//        public async Task<IActionResult> Put(long id, [FromBody] UpdateUserGroupCommand command)
//        {
//            command.Id = id;
//            await _commandBus.SendAsync(command);
//            return NoContent();
//        }

//    }
//}
