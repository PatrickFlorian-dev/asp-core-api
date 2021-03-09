using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BASE.Models;

namespace core_api.Common
{
    public class JwtAuthenticationManager: IJwtAuthenticationManager
    {

        private DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.dbOptions);
        private readonly PasswordCrypter passwordCrypter;
        private readonly RefreshTokenGenerator refreshTokenGenerator = new RefreshTokenGenerator();

        public JwtAuthenticationManager()
        {
            this.passwordCrypter = new PasswordCrypter();
        }

        public AuthenticationResponse Authenticate(string username, string password)
        {
            string tokenKeyEnvStr = Environment.GetEnvironmentVariable("APP_TOKEN_KEY");

            AuthenticationResponse authResponse = new AuthenticationResponse();

            User checkUserExists = dbContext.Users
              .Where
              (u => u.Username.ToLower() == username.ToLower())
              .FirstOrDefault();

            // Username doesn't exist in user model 
            if (checkUserExists == null)
            {
                return authResponse;
            }

            string deCryptedPassword = passwordCrypter.DecryptPassword(checkUserExists.Password);

            // Password doesn't match, case sensitive
            if( deCryptedPassword != password)
            {
                return authResponse;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] tokenKey = Encoding.ASCII.GetBytes(tokenKeyEnvStr);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
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
            var refreshToken = refreshTokenGenerator.GenerateToken();

            authResponse.JwtToken = tokenHandler.WriteToken(token);
            authResponse.RefreshToken = refreshToken;

            return authResponse;

        }

    }
}
