using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
