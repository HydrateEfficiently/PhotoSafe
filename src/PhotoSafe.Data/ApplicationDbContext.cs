using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using PhotoSafe.Data.Identity;

namespace PhotoSafe.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Safe> Safes { get; set; }

        public DbSet<SafeContributor> SafeContributors { get; set; }

        public DbSet<SafeFollower> SafeFollowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Safe>(b =>
            {
                b.HasAnnotation("Relational:TableName", "Safes");
            });

            //modelBuilder.Entity<Safe>(b =>
            //{
            //    b.HasAnnotation("Relational:TableName", "SafeContributors");
            //});

            //modelBuilder.Entity<Safe>(b =>
            //{
            //    b.HasAnnotation("Relational:TableName", "SafeFollowers");
            //});
        }
    }
}
