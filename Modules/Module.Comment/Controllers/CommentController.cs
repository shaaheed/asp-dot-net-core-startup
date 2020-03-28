using System.Threading.Tasks;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Module.Comment.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/comments")]
    [ApiController]
    //[Resource(COMMENTS)]
    public class CommentController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CommentController(
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
            //var query = new GetCommentsQuery();
            //var r = await _queryBus.SendAsync(query);
            //return Ok(r);
            //return null;
        //}

        [HttpGet("{id}")]
        //[AuthorizeResource(Operation = READ_DETAILS)]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //[HttpPost]
        //[AuthorizeResource(Operation = CREATE)]
        //public async Task<IActionResult> Post([FromBody] CreateCommentCommand command)
        //{
        //    var newCommentId = await _commandBus.SendAsync(command);
        //    return Created($"api/comments/1", newCommentId);
        //}

        //[HttpPut("{id}")]
        //[AuthorizeResource(Operation = EDIT)]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //[AuthorizeResource(Operation = DELETE)]
        //public async Task<IActionResult> Delete([FromRoute] DeleteCommentCommand command)
        //{
        //    await _commandBus.SendAsync(command);
        //    return NoContent();
        //}

    }
}
