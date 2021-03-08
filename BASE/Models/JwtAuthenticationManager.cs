using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace core_api.Common
{
    public class JwtAuthenticationManager: IJwtAuthenticationManager
    {
        // Replace this with DB call
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password1" },
        };

        public string Authenticate(string username, string password)
        {
            string tokenKeyEnvStr = Environment.GetEnvironmentVariable("APP_TOKEN_KEY");

            // FOR TEST ONLY REPLACE WITH DB CALL FROM USERS TABLE
            if (users != null)

            if (users.Any( u => u.Key != username && u.Value != password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(tokenKeyEnvStr);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
