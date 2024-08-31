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
                new Product { Id = 1, CategoryId = 1, Price = 3700.0M, Description = "", Name = "AMD Ryzen 5 5500U", Image = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRC98q4Vog6E0ThvsYJZ9M4zQYc7dC-BPrOut3rXMOpAHCgdRd4wlG7b7Y2Ml30vh9ijbrRhVrhizkWlyfQRB2AzspjWn3WTg4muTZFkWA&usqp=CAE" },
                new Product { Id = 2, CategoryId = 1, Price = 26406.0M, Description = "", Name = "intel core i9 14900k", Image = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTR0a-LCLAsE8kD7EyVZtQ4fWuOJFUr7om5GatUqr_LNAkbon0RnDxfWLE-uxZhFHuL_EWYtSRj3M5MTWlQsVymGKfBaDkbjBySMoIwj6qDdHa7xTmQOVD1&usqp=CAE" },
                new Product { Id = 3, CategoryId = 1, Price = 512876.0M, Description = "", Name = "AMD Ryzen Threadripper PRO 7995WX", Image = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTTuRvD4ecfGFUT5OPX7Y0DUMVCa91IHyzbeqwO3TY6UNwhpfJoB6Harwwm83LcDEfP1bYo34LvJH-PkaKODY8Xwh-x1c1R6pqW_oRaeWDdkMjMTSWIzN8-gg&usqp=CAE" },
                new Product { Id = 4, CategoryId = 2, Price = 88999.0M, Description = "", Name = "Nvidia RTX 4090", Image = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcT_OzFW3PueJdquyAqLvXML8ex14absxwEKb9_ai1zWa3_bzk-GccmBsWblN47cJQXndg_ni1lcz8v1y0xTs3BGiu8NSgRXCYRElUKdTvyKjySYjbPQIQz8&usqp=CAE" },
                new Product { Id = 5, CategoryId = 2, Price = 7999.0M, Description = "", Name = "AMD RX 6600", Image = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSN-HOzsGtF5sr9xFHO2ttuITyboTba__ey5QJXz5_vfQT2t_qdV9-qRnqgHlK4tvbY7DoprOEmbrqAW5VnDOZcdK2WkStUAMW-duANTnk&usqp=CAE" },
                new Product { Id = 6, CategoryId = 2, Price = 6500.0M, Description = "", Name = "Nvidia GeForce GTX 1080", Image = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSbElEyWjjPP1cYTHLoyhnkZ3EJDbFsXQD1pNvJe6bSr1F5uCmMFThovMt2hRaP8BASxdTA5P2M6WIGNKnNnIwHb6OKPIy0LoyD6GurgAXU4iEen_Foj5W4&usqp=CAE" }
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
