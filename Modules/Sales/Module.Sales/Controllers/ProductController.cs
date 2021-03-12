using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Module.Sales.Domain.Products;
using System;

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
        public Task<IActionResult> Delete(DeleteProductCommand command)
        {
            return DeleteAsync(command);
        }

        [HttpGet]
        //[RequirePermission(ProductList, ProductManage)]
        public Task<IActionResult> Gets()
        {
            return OkAsync(new GetProductsQuery());
        }

        [HttpGet("{id}")]
        //[RequirePermission(ProductView, ProductManage)]
        public Task<IActionResult> Get(Guid id)
        {
            return OkAsync(new GetProductQuery { Id = id });
        }
    }
}
