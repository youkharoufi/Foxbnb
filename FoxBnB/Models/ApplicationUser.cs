using Microsoft.AspNetCore.Identity;

namespace FoxBnB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePicUrl { get; set; }

        public string RoleName { get; set; }

        public string? Token { get; set; }
    }
}
