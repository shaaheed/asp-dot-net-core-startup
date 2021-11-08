using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Msi.Utilities.Filter;
using Module.Integrations.Domain;

namespace Module.Sales.Controllers
{
    [Route("api/integrations/connectors")]
    [ApiController]
    [ETag]
    public class ConnectorController : BaseController
    {
        [HttpPost]
        //[RequirePermission(CustomerCreate, CustomerManage)]
        public async Task<IActionResult> Post([FromBody] CreateConnectorCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(CustomerUpdate, CustomerManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateConnectorCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(CustomerDelete, CustomerManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteConnectorCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(CustomerList, CustomerManage)]
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            var query = new GetConnectorsQuery
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(CustomerView, CustomerManage)]
        public Task<IActionResult> Get([FromRoute] GetConnectorQuery query)
        {
            return OkAsync(query);
        }
    }
}
