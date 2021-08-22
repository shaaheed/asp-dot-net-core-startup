using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Module.Sales.Domain.Contacts;
using System;
using Msi.Utilities.Filter;
using Msi.Data.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Module.Sales.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    [ETag]
    public class ContactController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactController(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

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
