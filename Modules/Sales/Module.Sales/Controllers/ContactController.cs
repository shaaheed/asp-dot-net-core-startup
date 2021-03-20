using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Module.Sales.Domain.Contacts;
using System;
using Msi.Utilities.Filter;

namespace Module.Sales.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    [ETag]
    public class ContactController : BaseController
    {

        [HttpPost]
        //[RequirePermission(CustomerCreate, CustomerManage)]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(CustomerUpdate, CustomerManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateContactCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(CustomerDelete, CustomerManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteContactCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(CustomerList, CustomerManage)]
        public Task<IActionResult> Gets([FromQuery] SearchOptions searchOptions, [FromQuery] PagingOptions pagingOptions)
        {
            var query = new GetContactsQuery
            {
                PagingOptions = pagingOptions,
                SearchOptions = searchOptions
            };
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(CustomerView, CustomerManage)]
        public Task<IActionResult> Get([FromRoute] GetContactQuery query)
        {
            return OkAsync(query);
        }
    }
}
