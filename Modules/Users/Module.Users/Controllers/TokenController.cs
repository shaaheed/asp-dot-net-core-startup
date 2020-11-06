using Microsoft.AspNetCore.Mvc;
using Module.Users.Domain;
using Msi.Web;
using System.Threading.Tasks;

namespace Modules.User.Controllers
{

    [ApiController]
    [Route("api/token")]
    public class TokenController : BaseController
    {

        [HttpPost]
        public Task<IActionResult> Post([FromBody]CreateTokenCommand command)
        {
            return OkOrUnauthorizeAsync(command);
        }

        [HttpPost("refresh")]
        public Task<IActionResult> Refresh([FromBody]RefreshTokenCommand command)
        {
            return OkAsync(command);
        }

        [HttpPost("revoke")]
        public Task<IActionResult> Revoke([FromBody]RevokeTokenCommand command)
        {
            return OkAsync(command);
        }

    }
}
