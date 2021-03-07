using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api.Common
{
    public class PasswordCrypter
    {
        public static string secretKey = Environment.GetEnvironmentVariable("APP_SECRET_KEY");
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += secretKey;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string DecryptPassword(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            return result.Substring(0, result.Length - secretKey.Length);
        }

    }
}
