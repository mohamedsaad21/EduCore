using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using EduCore.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class EnrollmentService : IEnrollmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public EnrollmentService(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<List<Enrollment>> GetUserEnrollmentsListAsync()
    {
        return await _unitOfWork.Enrollments.GetTableNoTracking().ToListAsync();
    }

    public async Task<bool> CheckEnrollmentAsync(Course course, User user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);
        var enrolledList = await GetUserEnrollmentsListAsync();
        return userRoles.Any(r => r == Roles.Admin) || course.InstructorId == user.Id || enrolledList.Any(e => e.CourseId == course.Id && e.UserId == user.Id);
    }
}
