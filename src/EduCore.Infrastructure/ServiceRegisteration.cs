using CloudinaryDotNet;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using EduCore.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace EduCore.Infrastructure;

public static class ServiceRegisteration
{
    public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>(option =>
        {
            // Password settings.
            option.Password.RequireDigit = true;
            option.Password.RequireLowercase = true;
            option.Password.RequireNonAlphanumeric = true;
            option.Password.RequireUppercase = true;
            option.Password.RequiredLength = 6;
            option.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            option.Lockout.MaxFailedAccessAttempts = 5;
            option.Lockout.AllowedForNewUsers = true;

            // User settings.
            option.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            option.User.RequireUniqueEmail = true;
            option.SignIn.RequireConfirmedEmail = true;

        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        //JWT Authentication
        var jwtSettings = new JwtSettings();
        configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);

        var emailSettings = new EmailSettings();
        configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

        var cloudinarySettings = new CloudinarySettings();
        configuration.GetSection(nameof(cloudinarySettings)).Bind(cloudinarySettings);

        services.AddSingleton(jwtSettings);
        services.AddSingleton(emailSettings);
        services.AddSingleton(cloudinarySettings);

        var cloudinary = new Cloudinary(cloudinarySettings.Url);
        cloudinary.Api.Secure = true;
        services.AddSingleton(cloudinary);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
       .AddJwtBearer(o =>
       {
           o.RequireHttpsMetadata = false;
           o.SaveToken = true;
           o.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidIssuer = jwtSettings.Issuer,
               ValidAudience = jwtSettings.Audience,
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
           };
       });

        //Swagger Gn
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "EduCore",
                Description = "",
                TermsOfService = new Uri("https://www.linkedin.com/in/mohamedsaad14/"),
                Contact = new OpenApiContact
                {
                    Name = "Mohamed Saad",
                    Email = "mohamedsaad2756@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/mohamedsaad14/")
                },
                License = new OpenApiLicense
                {
                    Name = "My license",
                    Url = new Uri("https://www.linkedin.com/in/mohamedsaad14/")
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your api key"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });


        return services;
    }
}
