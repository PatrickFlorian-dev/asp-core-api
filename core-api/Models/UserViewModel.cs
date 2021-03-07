using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_api.Models
{
    public class UserViewModel
    {
        public Int64 UserId { get; set; }

        public String Username { get; set; }

        public String EmailAddress { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Int32 AuthLevel { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
