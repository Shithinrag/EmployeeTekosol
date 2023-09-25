using EmployeeTekosol.Repository.Abstraction;
using EmployeeTekosol.Repository.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace EmployeeTekosol.Repository.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            var issuer = _configuration["AuthSettings:Issuer"];
            var audience = _configuration["AuthSettings:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["AuthSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Double.Parse(_configuration["AuthSettings:ExpiryTimeInMinutes"])),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);           
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }       
    }
}


    

