using HealthState.Aplicacion.Auth.Commands;
using HealthState.Aplicacion.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ApiController
    {

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginCommand command)
        {
            try
            {
                var user = await Mediator.Send(command);

                return Ok(new
                {
                    isSuccess = true,
                    token = user.Token,
                    rolId = user.RolId
                });
            }
            catch (BusinessException ex)
            {
                return Unauthorized(new
                {
                    isSuccess = false,
                    message = ex.Message
                });
            }
        }
    }
}