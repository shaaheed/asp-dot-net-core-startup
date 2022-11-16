using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Module.Sales.Domain.Units;
using Msi.Utilities.Filter;
using Module.Sales.Domain;

namespace Module.Sales.Controllers
{
    [Route("api/priceLevels")]
    [ApiController]
    [ETag]
    public class PriceLevelController : BaseController
    {

        [HttpPost]
        //[RequirePermission(ProductCreate, ProductManage)]
        public async Task<IActionResult> Post([FromBody] CreatePriceLevelCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdatePriceLevelCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete([FromRoute] DeletePriceLevelCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            var query = new GetPriceLevelsQuery()
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetPriceLevelQuery query)
        {
            return OkAsync(query);
        }
    }
}
