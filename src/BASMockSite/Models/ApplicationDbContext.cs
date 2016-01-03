using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using BASMockSite.Models;

namespace BASMockSite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<ProgramManagers>()
            //    .HasOne(p => p.College)
            //    .WithMany(s => s.ProgramManagers)
            //    .HasForeignKey(p => p.CollegeID)
            //    .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            //builder.Entity<ProgramManagers>()
            //    .HasMany("Degrees")
            //    .WithOne("ProgramManagers")
            //    .HasForeignKey("ProgramManagerID")
            //    .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            //builder.Entity<Degrees>()
            //    .HasOne(d => d.ProgramManagers)
            //    .WithMany(pm => pm.Degrees)
            //    .HasForeignKey(d => d.ProgramManagerID)
            //    .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);
        }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<ProgramStructure> ProgramStructures { get; set; }
        public DbSet<ProgramEntry> ProgramEntries { get; set; }
        public DbSet<ProgramManager> ProgramManagers { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
