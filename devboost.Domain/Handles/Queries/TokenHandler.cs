using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries
{
    public class TokenHandler : ITokenHandler
    {
        readonly string _jwtKey;

        public TokenHandler(IConfiguration configuration)
        {
            _jwtKey = configuration["jwt:key"];
        }

        public async Task<string> GenerateToken(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Role))
                return await Task.FromResult(string.Empty);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(securityToken));
        }
    }
}
