using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class User :IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
