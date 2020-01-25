using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Sales.Domain.Products;
using System.Threading.Tasks;

namespace Module.Sales.Controllers
{
    [Route("api/products")]
    [ApiController]
    //[Resource(USERS)]
    [ETag]
    public class ProductController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public ProductController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateProductCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]UpdateProductCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteProductCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Gets()
        {
            var products = await _queryBus.SendAsync(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var product = await _queryBus.SendAsync(new GetProductQuery { Id = id });
            return Ok(product);
        }
    }
}
