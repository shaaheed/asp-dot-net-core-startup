using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Module.Sales.Domain.Products;
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
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        //[RequirePermission(ProductUpdate, ProductManage)]
        public Task<IActionResult> Put(Guid id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            return OkAsync(command);
        }

        [HttpDelete("{id}")]
        //[RequirePermission(ProductDelete, ProductManage)]
        public Task<IActionResult> Delete([FromRoute] DeleteProductCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets([FromQuery] FilterOptions filterOptions)
        {
            return OkAsync(new GetProductsQuery().AddFilterOptions(filterOptions));
        }

        [HttpGet("transactions")]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> GetTransactions([FromQuery] FilterOptions filterOptions)
        {
            return OkAsync(new GetProductTransactionsQuery().AddFilterOptions(filterOptions));
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get([FromRoute] GetProductQuery query)
        {
            return OkAsync(query);
        }
    }
}
