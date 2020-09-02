using Microsoft.AspNetCore.Identity;

namespace Complain_System.Models
{
    public class AppRole:IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string roleName) : base(roleName)
        {

        }
    }
}