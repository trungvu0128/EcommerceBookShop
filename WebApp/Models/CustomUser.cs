using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int UserNameChangeLimit { get; set; } = 10;
        public string ProfilePicture { get; set; }
    }
}
