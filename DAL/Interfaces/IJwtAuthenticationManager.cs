using BASE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        AuthenticationResponse Authenticate(string username, string password);
    }
}
