using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Infrastructure.Seeder;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<Role> roleManager)
    {
        var roles = new string[] { Roles.Admin, Roles.Instructor, Roles.Student };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new Role(role));
        }
    }
}
