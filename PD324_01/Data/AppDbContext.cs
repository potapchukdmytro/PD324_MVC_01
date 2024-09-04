using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PD324_01.Models;
using PD324_01.Models.Identity;

namespace PD324_01.Data
{
    public class AppDbContext
        : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Processors" },
                new Category { Id = 2, Name = "Videocards" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Price = 3700.0M, Description = "", Name = "AMD Ryzen 5 5500U", Image = "910632df-d958-45ee-a84e-1ec107893d66.webp" },
                new Product { Id = 2, CategoryId = 1, Price = 26406.0M, Description = "", Name = "intel core i9 14900k", Image = "f1e28f88-7de9-4468-9673-4e78201a89fb.webp" },
                new Product { Id = 3, CategoryId = 1, Price = 512876.0M, Description = "", Name = "AMD Ryzen Threadripper PRO 7995WX", Image = "8db30c71-35a1-4903-b279-dfc1c92bdd8d.webp" },
                new Product { Id = 4, CategoryId = 2, Price = 88999.0M, Description = "", Name = "Nvidia RTX 4090", Image = "fd47a589-db2d-4804-b32b-40007955f610.webp" },
                new Product { Id = 5, CategoryId = 2, Price = 7999.0M, Description = "", Name = "AMD RX 6600", Image = "8681144b-62b0-4344-a0d9-191d8cc8955b.webp" },
                new Product { Id = 6, CategoryId = 2, Price = 6500.0M, Description = "", Name = "Nvidia GeForce GTX 1080", Image = "068c9a22-dc0b-4033-8ad4-c55ad2f1a444.webp" }
                );

            modelBuilder.Entity<User>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Role>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
