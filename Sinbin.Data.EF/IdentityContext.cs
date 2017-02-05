using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Sinbin.Data.EF
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext() : base("Sinbin") { }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
            .ToTable("Users");

            modelBuilder.Entity<User>()
            .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<UserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");

            modelBuilder.Entity<UserLogin>()
                .ToTable("UserLogins");
        }
    }
}
