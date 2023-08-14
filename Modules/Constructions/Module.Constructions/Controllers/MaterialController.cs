using Microsoft.AspNetCore.Mvc;
using Module.Constructions.Domain;
using System.Threading.Tasks;
using System;
using Msi.Web;
using static Module.Constructions.Domain.PermissionCodes;
using Msi.Utilities.Filter;
using Module.Systems.Attributes;

namespace Module.Constructions
{
    [Route("api/constructions/materials")]
    [ApiController]
    [ETag]
    public class MaterialController : BaseController
    {

        [HttpPost]
        [RequireAnyPermission(MaterialCreate, MaterialFullAccess)]
        public async Task<IActionResult> Post([FromBody] CreateMaterialCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequireAnyPermission(MaterialUpdate, MaterialFullAccess)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateMaterialCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        [RequireAnyPermission(MaterialDelete, MaterialFullAccess)]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMaterialCommand { Id = id };
            return DeleteAsync(command);
        }

        [HttpGet]
        [RequireAnyPermission(MaterialList, MaterialFullAccess)]
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            var query = new GetMaterialsQuery().AddFilterOptions(filterOptions);
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        [RequireAnyPermission(MaterialView, MaterialFullAccess)]
        public Task<IActionResult> Get(Guid id)
        {
            return OkAsync(new GetMaterialQuery { Id = id });
        }
    }
}
