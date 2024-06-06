using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public Context()
        {
            
        }
        public DbSet<UrlManagement> UrlManagements { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UrlManagement>().HasOne(u => u.User).WithMany(u => u.UrlManagements).HasForeignKey(u => u.UserId);
        }
    }
}
