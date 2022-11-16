using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using System;
using Module.Sales.Domain.Units;
using Msi.Utilities.Filter;

namespace Module.Sales.Controllers
{
    [Route("api/terms")]
    [ApiController]
    [ETag]
    public class TermController : BaseController
    {

        [HttpPost]
        //[RequirePermission(ProductCreate, ProductManage)]
        public async Task<IActionResult> Post([FromBody] CreateTermCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateTermCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteTermCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            var query = new GetTermsQuery()
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetTermQuery query)
        {
            return OkAsync(query);
        }
    }
}
