using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FamilyPhotosWithIdentity.Models;
using FamilyPhotosWithIdentity.Models.Github;

namespace FamilyPhotosWithIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        //model hozzáadása ef hez hogy kezelje az adatbázisban
        public DbSet<GithubRequest> GithubRequests {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<ApplicationRole>(entity =>
            //{
            //    entity.ToTable("AspNetRoles");
            //    entity.Property(e => e.Id).HasColumnName("Id");
            //});
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    }
}
