using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using PhotoSafe.Data.Identity;

namespace PhotoSafe.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Safe> Safes { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<ImageUpload> ImageUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Safe>(b =>
            {
                b.HasAnnotation("Relational:TableName", "Safes");
            });

            modelBuilder.Entity<Deposit>(b =>
            {
                b.HasAnnotation("Relational:TableName", "Deposits");
            });

            modelBuilder.Entity<Photo>(b =>
            {
                b.HasAnnotation("Relational:TableName", "Photos");
            });

            modelBuilder.Entity<ImageUpload>(b =>
            {
                b.HasAnnotation("Relational:TableName", "ImageUploads");
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
