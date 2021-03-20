using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Module.Sales.Domain.Units;

namespace Module.Sales.Controllers
{
    [Route("api/units")]
    [ApiController]
    [ETag]
    public class UnitController : BaseController
    {

        [HttpPost]
        //[RequirePermission(ProductCreate, ProductManage)]
        public async Task<IActionResult> Post([FromBody] CreateUnitCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateUnitCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteUnitCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets()
        {
            return OkAsync(new GetUnitsQuery());
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetUnitQuery query)
        {
            return OkAsync(query);
        }
    }
}
