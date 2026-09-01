using EduCore.Domain.Constants;
using EduCore.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Infrastructure.Seeder;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<User> userManager)
    {
        var user = new User
        {
            FullName = "Mohamed Saad",
            UserName = "admin",
            Email = "admin@educore.com",
            EmailConfirmed = true
        };
        var password = "Ad@12345";
        await userManager.CreateAsync(user, password);
        await userManager.AddToRolesAsync(user, new List<string> { Roles.Admin, Roles.Instructor, Roles.Student });
        await userManager.UpdateAsync(user);
    }
}
