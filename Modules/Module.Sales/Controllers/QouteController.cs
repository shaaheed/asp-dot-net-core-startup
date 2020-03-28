using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Sales.Domain.Qoutes;
using System.Threading.Tasks;
using static Module.Sales.Common.Permissions;

namespace Module.Sales.Controllers
{
    [Route("api/qoutes")]
    [ApiController]
    [ETag]
    public class QouteController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public QouteController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        [RequirePermission(QouteCreate, QouteManage)]
        public async Task<ActionResult> Post([FromBody]CreateQouteCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        [RequirePermission(QouteUpdate, QouteManage)]
        public async Task<ActionResult> Put(long id, [FromBody]UpdateQouteCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [RequirePermission(QouteDelete, QouteManage)]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteQouteCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return NoContent();
        }

        [HttpGet]
        [RequirePermission(QouteList, QouteManage)]
        public async Task<ActionResult> Gets()
        {
            var qoutes = await _queryBus.SendAsync(new GetQoutesQuery());
            return Ok(qoutes);
        }

        [HttpGet("{id}")]
        [RequirePermission(QouteView, QouteManage)]
        public async Task<ActionResult> Get(long id)
        {
            var qoute = await _queryBus.SendAsync(new GetQouteQuery { Id = id });
            return Ok(qoute);
        }
    }
}
