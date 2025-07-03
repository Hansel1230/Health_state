using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Usuarios.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HealthState.Aplicacion.Common.Utils
{
    public class UtilidadesJwt : IUtilidadesJwt
    {
        private readonly IConfiguration _configuration;
        public UtilidadesJwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string encriptarSha256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string GenerarJwt(UsuarioModel modelo)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, modelo.Usuario1)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
