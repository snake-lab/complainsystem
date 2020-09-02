using Microsoft.AspNetCore.Identity;

namespace Complain_System.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
    }
}