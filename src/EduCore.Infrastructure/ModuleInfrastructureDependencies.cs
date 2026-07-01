using EduCore.Application.Abstracts;
using EduCore.Domain.Interfaces;
using EduCore.Infrastructure.Persistence.Repositories;
using EduCore.Infrastructure.Services;
using EduCore.Service.AuthServices.Implementations;
using EduCore.Service.Implementation;
using EduCore.Services.Implementation;
using Fawaterak.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EduCore.Infrastructure;

public static class ModuleInfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IApplicationUserService, ApplicationUserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ISectionService, SectionService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<ICourseProgressService, CourseProgressService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<IFawaterakPaymentService, FawaterakPaymentService>();
        return services;
    }
}
