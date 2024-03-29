﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.Web;
using Msi.Utilities.Filter;
using Module.Payments.Domain;

namespace Module.Payments.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : BaseController
    {

        [HttpGet("methods")]
        public Task<IActionResult> GetPaymentMethods([FromQuery] FilterOptions filterOptions)
        {
            var query = new GetPaymentMethodsQuery
            {
                FilterOptions = filterOptions
            };
            return OkAsync(query);
        }

        [HttpGet("create-info")]
        public Task<IActionResult> GetCreateInfo()
        {
            return OkAsync(new GetPaymentCreateInfoQuery());
        }

    }
}
