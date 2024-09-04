using Microsoft.AspNetCore.Identity;
using PD324_01.Models.Identity;

namespace PD324_01.Data
{
    public static class Seeder
    {
        public static async void SeedData(this IApplicationBuilder builder)
        {
            using(var scope = builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                if(!roleManager.Roles.Any())
                {
                    var admin = new Role
                    {
                        Name = Settings.AdminRole,
                        NormalizedName = Settings.AdminRole.ToUpper()
                    };

                    var user = new Role
                    { 
                        Name = Settings.UserRole,
                        NormalizedName = Settings.UserRole.ToUpper()
                    };

                    await roleManager.CreateAsync(admin);
                    await roleManager.CreateAsync(user);
                }
            }
        }
    }
}
