using Microsoft.AspNetCore.Mvc;
using Module.Systems.Attributes;
using Module.Organizations.Domain;
using System.Threading.Tasks;
using System;
using Msi.Web;
using static Module.Organizations.Domain.PermissionIds;
using Msi.Utilities.Filter;

namespace Module.Organizations
{
    [Route("api/organizations")]
    [ApiController]
    [ETag]
    public class OrganizationController : BaseController
    {

        public OrganizationController()
        {
            Console.WriteLine(HttpContext);
        }

        [HttpPost]
        [RequireAnyPermission(OrganizationCreate, OrganizationFullAccess)]
        public async Task<IActionResult> Post([FromBody]CreateOrganizationCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequireAnyPermission(OrganizationUpdate, OrganizationFullAccess)]
        public Task<IActionResult> Put(Guid id, [FromBody]UpdateOrganizationCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        [RequireAnyPermission(OrganizationDelete, OrganizationFullAccess)]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrganizationCommand { Id = id };
            return DeleteAsync(command);
        }

        [HttpGet]
        [RequireAnyPermission(OrganizationList, OrganizationFullAccess)]
        public Task<IActionResult> Gets([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var query = new GetOrganizationsQuery().AddPagingOptions(pagingOptions).AddSearchOptions(searchOptions);
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        [RequireAnyPermission(OrganizationView, OrganizationFullAccess)]
        public Task<IActionResult> Get(Guid id)
        {
            return OkAsync(new GetOrganizationQuery { Id = id });
        }
    }
}
