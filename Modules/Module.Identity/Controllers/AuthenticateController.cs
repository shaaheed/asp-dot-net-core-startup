using Core.Infrastructure.Commands;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Module.Identity.Domain.Login;
using System.Threading.Tasks;

namespace Module.Identity.Controllers
{

    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticateController : ControllerBase
    {

        private readonly ICommandBus _commandBus;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IWebHostEnvironment _environment;

        public AuthenticateController(
            ICommandBus commandBus,
            IIdentityServerInteractionService interaction,
            IWebHostEnvironment environment)
        {
            _commandBus = commandBus;
            _interaction = interaction;
            _environment = environment;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            var response = await _commandBus.SendAsync(command);
            if(response.Authenticated)
            {
                //await HttpContext.SignInAsync(response.UserId.ToString(), command.Username);
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpGet("logout")]
        [Route("Logout")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var context = await _interaction.GetLogoutContextAsync(logoutId);
            bool showSignoutPrompt = true;

            if (context?.ShowSignoutPrompt == false)
            {
                // it's safe to automatically sign-out
                showSignoutPrompt = false;
            }

            if (User?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await HttpContext.SignOutAsync();
                //await HttpContext.SignOutAsync("Cookies");
                //await HttpContext.SignOutAsync("oidc");
            }

            // no external signout supported for now (see \Quickstart\Account\AccountController.cs TriggerExternalSignout)
            return Ok(new
            {
                showSignoutPrompt,
                ClientName = string.IsNullOrEmpty(context?.ClientName) ? context?.ClientId : context?.ClientName,
                context?.PostLogoutRedirectUri,
                context?.SignOutIFrameUrl,
                logoutId
            });
        }

        [HttpGet("error")]
        public async Task<IActionResult> Error(string errorId)
        {
            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);

            if (message != null)
            {
                if (!_environment.IsDevelopment())
                {
                    // only show in development
                    message.ErrorDescription = null;
                }
            }

            return Ok(message);
        }

    }
}
