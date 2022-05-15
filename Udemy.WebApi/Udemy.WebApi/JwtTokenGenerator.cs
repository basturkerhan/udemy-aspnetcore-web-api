using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Udemy.WebApi
{
    public class JwtTokenGenerator
    {
        public string GenerateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Erhanerhanerhan1."));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // role eklemek:
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Member"));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer:"https://localhost", 
                audience:"https://localhost",
                notBefore: System.DateTime.Now,
                expires: System.DateTime.Now.AddMinutes(1),
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
