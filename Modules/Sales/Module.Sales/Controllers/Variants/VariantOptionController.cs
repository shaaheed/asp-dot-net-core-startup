using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Module.Sales.Domain;
using Msi.Utilities.Filter;

namespace Module.Sales.Controllers
{
    [Route("api/variants/{variantId}/options")]
    [ApiController]
    [ETag]
    public class VariantOptionController : BaseController
    {

        [HttpPost]
        //[RequirePermission(ProductCreate, ProductManage)]
        public async Task<IActionResult> Post(Guid variantId, [FromBody] CreateVariantOptionCommand command)
        {
            command.VariantId = variantId;
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid variantId, Guid id, [FromBody] UpdateVariantOptionCommand command)
        {
            command.Id = id;
            command.VariantId = variantId;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete(Guid variantId, [FromRoute] DeleteVariantOptionCommand command)
        {
            command.VariantId = variantId;
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets(Guid variantId, [FromQuery] FilterOptions filterOptions)
        {
            var query = new GetVariantOptionsQuery()
            {
                VariantId = variantId,
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetVariantOptionQuery query)
        {
            return OkAsync(query);
        }
    }
}
