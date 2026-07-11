using EduCore.Domain.Entities.Identity;
using EduCore.Infrastructure.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EduCore.API.Extensions;

public static class WebApplicationExtensions
{
    public async static Task UseApiPipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "EduCore V1");
            //options.RoutePrefix = string.Empty;
            options.RoutePrefix = "swagger";
        });
        //}

        var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);

        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseCors("DevelopmentPolicy");

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        //app.UseMiddleware<ErrorHandlerMiddleware>();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            await RoleSeeder.SeedAsync(roleManager);
            await UserSeeder.SeedAsync(userManager);
        }
    }
}
