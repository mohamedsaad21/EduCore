using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class CourseProgressService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : ICourseProgressService
{
    public async Task<bool> IsCompletedFullCourse(Course Course)
    {
        var userId = await currentUserService.GetCurrentUserId();
        var totalContent = await unitOfWork.Contents.GetTableNoTracking().CountAsync(c => c.Section.CourseId == Course.Id);
        var totalCompleted = await unitOfWork.UserCourseProgresses.GetTableNoTracking().CountAsync(p => p.UserId == userId && p.Content.Section.CourseId == Course.Id && p.IsCompleted);
        var percent = Math.Round(((double)totalCompleted / totalContent) * 100, 2);
        return percent == 100;
    }
}