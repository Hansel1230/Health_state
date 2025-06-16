using HealthState.Application.Auth.Services;
using Microsoft.AspNetCore.Identity;

namespace HealthState.Infraestructura.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> hasher = new();

        public string HashPassword(string password)
        {
            return hasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hash, string providedPassword)
        {
            var result = hasher.VerifyHashedPassword(null, hash, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
