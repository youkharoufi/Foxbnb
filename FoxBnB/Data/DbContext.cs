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
        public DbSet<DayInfo> DaysInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<DateRangeRes>()
            //    .HasMany(p => p.DaysInRange)
            //    .WithOne(d => d.DateRangeRes)
            //    .HasForeignKey(d => d.DateRangeResId);
        }

    }

}


