using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Models
{
    public class AuthenticationResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
