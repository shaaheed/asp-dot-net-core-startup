using Microsoft.AspNetCore.Mvc;
using Module.Organizations.Domain;
using System.Threading.Tasks;
using System;
using Msi.Web;
using static Module.Organizations.Domain.PermissionIds;
using Msi.Utilities.Filter;

namespace Module.Organizations
{
    [Route("api/organizations/{organizationId}/currencies")]
    [ApiController]
    [ETag]
    public class OrganizationCurrencyController : BaseController
    {

        public OrganizationCurrencyController()
        {
            Console.WriteLine(HttpContext);
        }

        [HttpPost]
        //[RequireAnyPermission(OrganizationCreate, OrganizationFullAccess)]
        public async Task<IActionResult> Post(Guid organizationId, [FromBody] CreateOrganizationCurrencyCommand command)
        {
            command.OrganizationId = organizationId;
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequireAnyPermission(OrganizationUpdate, OrganizationFullAccess)]
        public Task<IActionResult> Put(Guid organizationId, Guid id, [FromBody] UpdateOrganizationCurrencyCommand command)
        {
            command.OrganizationId = organizationId;
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequireAnyPermission(OrganizationDelete, OrganizationFullAccess)]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrganizationCurrencyCommand { Id = id };
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequireAnyPermission(OrganizationList, OrganizationFullAccess)]
        public Task<IActionResult> Gets(Guid organizationId, [FromQuery] FilterOptions filterOptions)
        {
            var query = new GetOrganizationCurrenciesQuery();
            query.OrganizationId = organizationId;
            query.AddFilterOptions(filterOptions);
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequireAnyPermission(OrganizationView, OrganizationFullAccess)]
        public Task<IActionResult> Get(Guid id)
        {
            return OkAsync(new GetOrganizationCurrencyQuery { Id = id });
        }
    }
}
