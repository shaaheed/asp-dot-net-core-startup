using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Module.Sales.Domain.Taxes;

namespace Module.Sales.Controllers
{
    [Route("api/taxes")]
    [ApiController]
    [ETag]
    public class TaxController : BaseController
    {

        [HttpPost]
        //[RequirePermission(ProductCreate, ProductManage)]
        public async Task<IActionResult> Post([FromBody] CreateTaxCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateTaxCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteTaxCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets()
        {
            return OkAsync(new GetTaxesQuery());
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetTaxQuery query)
        {
            return OkAsync(query);
        }
    }
}
