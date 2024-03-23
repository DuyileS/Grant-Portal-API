using Microsoft.AspNetCore.Identity;

namespace GMP.API.Models.Domain
{
    public class User: IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }
}
