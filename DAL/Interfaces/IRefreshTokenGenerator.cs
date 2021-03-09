using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Models
{
    public interface IRefreshTokenGenerator
    {
        string GenerateToken();
    }
}
