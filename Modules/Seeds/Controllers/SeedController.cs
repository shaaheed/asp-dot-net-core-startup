using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Msi.Data.Abstractions;
using Msi.Core;
using Msi.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Module.Seeds.Controllers
{
    [Route("api/seeds")]
    [ApiController]
    public class SeedController : BaseController
    {

        private readonly IUnitOfWork _unitOfWork;

        public SeedController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("run")]
        public async Task<IActionResult> Run()
        {
            var seeders = Global.GetGenericImplementations(typeof(ISeeder<>));

            Dictionary<int, List<object>> dict = new Dictionary<int, List<object>>();
            foreach (var seeder in seeders)
            {
                if (seeder.IsClass && !seeder.IsAbstract)
                {
                    var propInfo = seeder.GetProperty("Order");
                    if (propInfo != null)
                    {
                        var instance = Activator.CreateInstance(seeder);
                        var order = Convert.ToInt32(propInfo.GetValue(instance, null));
                        if (!dict.ContainsKey(order))
                        {
                            dict.Add(order, new List<object>());
                        }
                        dict[order].Add(instance);
                    }
                }
            }

            var keys = dict.Keys.ToList().OrderBy(x => x);
            foreach (var key in keys)
            {
                var instances = dict[key];
                foreach (var instance in instances)
                {
                    var method = instance?.GetType()?.GetMethod("Seed");
                    var task = method?.Invoke(instance, new object[] { _unitOfWork }) as Task;
                    await task.ConfigureAwait(false);
                }
            }
            var result = await _unitOfWork.SaveChangesAsync();
            var obj = new { };
            return new OkObjectResult(obj);
        }

    }
}
