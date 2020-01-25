﻿using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Module.Sales.Domain.Customers;
using System.Threading.Tasks;

namespace Module.Sales.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [ETag]
    public class CustomerController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CustomerController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateCustomerCommand command)
        {
            var r = await _commandBus.SendAsync(command);
            return Created("abc", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]UpdateCustomerCommand command)
        {
            command.Id = id;
            var r = await _commandBus.SendAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var r = await _commandBus.SendAsync(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> Gets()
        {
            var products = await _queryBus.SendAsync(new GetCustomersQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var product = await _queryBus.SendAsync(new GetCustomerQuery { Id = id });
            return Ok(product);
        }
    }
}
