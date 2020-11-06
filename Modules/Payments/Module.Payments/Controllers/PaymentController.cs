using Msi.Mediator.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Module.Payments.Domain;
using System.Threading.Tasks;

namespace Module.Payments.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public PaymentController(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet("payment-methods")]
        public async Task<ActionResult> GetPaymentMethods()
        {
            var query = new GetPaymentMethodsQuery();
            var results = await _queryBus.SendAsync(query);
            return Ok(results);
        }

    }
}
