using System.Collections.Generic;
using System.Reflection.Emit;
using FoxBnB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Property> Properties { get; set; }

    }

}


