using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Module.IdentityServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {

        public ClientsController()
        {

        }

    }
}
