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
        public DbSet<AppUser> AppUsers{ get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<ComplainBox> ComplainBoxes { get; set; }
        public DbSet<ComplainStatus> complainStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
