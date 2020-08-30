using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complain_System.Models
{

    public class ComplainDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public ComplainDbContext(DbContextOptions<ComplainDbContext> options) : base(options)
    {

    }
    //tables________________

}
}
