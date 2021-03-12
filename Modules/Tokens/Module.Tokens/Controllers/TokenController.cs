using Microsoft.AspNetCore.Mvc;
using Module.Tokens.Domain;
using Msi.Web;
using System.Threading.Tasks;

namespace Module.Tokens.Controllers
{

    [ApiController]
    [Route("api/token")]
    public class TokenController : BaseController
    {

        [HttpPost]
        public Task<IActionResult> Post([FromBody] CreateTokenCommand command)
        {
            return OkOrUnauthorizeAsync(command);
        }

        [HttpPost("refresh")]
        public Task<IActionResult> Refresh([FromBody] RefreshTokenCommand command)
        {
            return OkAsync(command);
        }

        [HttpPost("revoke")]
        public Task<IActionResult> Revoke([FromBody] RevokeTokenCommand command)
        {
            return OkAsync(command);
        }

        [HttpGet("echo")]
        public IActionResult Echo()
        {
            return Ok("Hello Word");
        }

    }
}
