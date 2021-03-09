using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BASE.Models
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public string GenerateToken()
        {
            var randomNumber = new byte[32];

            using ( var randomNumberGenerator = RandomNumberGenerator.Create() )
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
