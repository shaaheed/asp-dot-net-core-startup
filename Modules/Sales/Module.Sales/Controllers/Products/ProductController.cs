using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Module.Sales.Domain.Items;
using System;
using Msi.Utilities.Filter;

namespace Module.Sales.Controllers
{
    [Route("api/products")]
    [ApiController]
    [ETag]
    public class ProductController : BaseController
    {

        [HttpPost]
        //[RequirePermission(ProductCreate, ProductManage)]
        public async Task<IActionResult> Post([FromBody] CreateItemCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateItemCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteItemCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            return OkAsync(new GetItemsQuery().AddFilterOptions(filterOptions));
        }

        [HttpGet("transactions")]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> GetTransactions([FromQuery] FilterOptions filterOptions)
        {
            return OkAsync(new GetProductTransactionsQuery().AddFilterOptions(filterOptions));
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetItemQuery query)
        {
            return OkAsync(query);
        }
    }
}
