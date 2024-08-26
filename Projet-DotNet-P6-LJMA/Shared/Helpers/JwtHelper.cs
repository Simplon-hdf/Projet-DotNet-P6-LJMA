using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Projet_DotNet_P6_LJMA.Infrastructure.Configurations;
using Projet_DotNet_P6_LJMA.Shared.DTOs;

namespace Projet_DotNet_P6_LJMA.Shared.Helpers
{
    public class JwtHelper
    {
        private readonly string _jwtSecret;
        public JwtHelper(IConfiguration configuration)
            => _jwtSecret = ConfigurationValidator.GetJwtSecret(configuration);

        public string CreateJWT(AuthentificateDTO authentificateDTO)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, authentificateDTO.Id.ToString()),
                new Claim(ClaimTypes.Name, authentificateDTO.Nom),
                new Claim(ClaimTypes.GivenName, authentificateDTO.Prenom),
                new Claim(ClaimTypes.Role, authentificateDTO.Role)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public string? RefreshToken(string expiredToken)
        {
            var principal = GetPrincipleFromExpiredToken(expiredToken);

            var userIdClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var nom = principal.FindFirstValue(ClaimTypes.Name);
            var prenom = principal.FindFirstValue(ClaimTypes.GivenName);
            var role = principal.FindFirstValue(ClaimTypes.Role);

            if (string.IsNullOrEmpty(userIdClaim) || string.IsNullOrEmpty(nom) ||
                string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(role) ||
                !Guid.TryParse(userIdClaim, out Guid userId))
            {
                return null; // Informations manquantes ou invalides dans le token
            }

            var newToken = CreateJWT(new AuthentificateDTO
            {
                Id = userId,
                Nom = nom,
                Prenom = prenom,
                Role = role
            });

            return newToken;
        }
    }
}
