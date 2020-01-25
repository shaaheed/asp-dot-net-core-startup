using System.Threading.Tasks;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Module.Comment.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/commands")]
    [ApiController]
    //[Resource(COMMANDS)]
    public class CommandController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CommandController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        //[HttpGet]
        //[AuthorizeResource(Operation = READ_LIST)]
        //public async Task<ActionResult> Get()
        //{
        //    var query = new GetUsersQuery();
        //    var r = await _queryBus.SendAsync(query);
        //    return Ok(r);
        //}

        [HttpGet]
        //[AuthorizeResource(Operation = SYNC)]
        public async Task<ActionResult> Sync()
        {
            //var scanCommands = await _queryBus.SendAsync(new ScanCommandsQuery());
            //var command = new SyncCommand { Commands = scanCommands };
            //var r = await _commandBus.SendAsync(command);
            return null; //Ok(r);
        }

    }
}
