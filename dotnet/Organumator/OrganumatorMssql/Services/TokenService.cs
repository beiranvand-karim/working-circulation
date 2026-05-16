using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey symmetricSecurityKey;

        public TokenService(
            IConfiguration _configuration
            )
        {
            configuration = _configuration;
            symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
                );
        }

        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Email, appUser.Email),
                new(JwtRegisteredClaimNames.GivenName, appUser.UserName)
            };

            var creds = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha512Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}