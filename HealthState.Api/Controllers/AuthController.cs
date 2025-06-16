using HealthState.Aplicacion.Auth.Commands;
using HealthState.Aplicacion.Auth.Models;
using HealthState.Aplicacion.Common.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthState.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {

        private readonly JwtConfiguration jwtConfiguration;
        public AuthController(IOptions<JwtConfiguration> options)
        {
            jwtConfiguration = options.Value;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginCommand command)
        {
            var data = await Mediator.Send(command);
            var token = BuildTokenFromModel(data);
            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<LoginResponseModel> Renew()
        {
            var claims = HttpContext.User.Claims;
            return BuildToken(claims);
        }

        private LoginResponseModel BuildTokenFromModel(AuthApiUserModel model)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, model.UserName));
            claims.Add(new Claim("Office", model.OfficeCode ?? ""));
            claims.Add(new Claim("FullName", model.FullName));
            claims.Add(new Claim("Terminal", model.Terminal  ?? ""));
            claims.Add(new Claim("AppCode", model.AppCode));
            claims.Add(new Claim("UserCode", model.UserCode));
            claims.Add(new Claim("Id", model.Id.ToString()));
            claims.Add(new Claim("Profile", model.Profiles.Name));

            foreach (var item in model.Profiles.Transactions)
                claims.Add(new Claim(ClaimTypes.Role, item.Code));

            return BuildToken(claims);
        }

        private LoginResponseModel BuildToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expire = jwtConfiguration.Expire;
            var expireTime = DateTime.UtcNow.AddMinutes(jwtConfiguration.ExpireTime);

            var token = new JwtSecurityToken(issuer: null,
                                             audience: null,
                                             claims: claims,
                                             expires: expire ? expireTime : null,
                                             signingCredentials: credential);
            return new LoginResponseModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expire = expire ? expireTime : null,
            };
        }
    }
}