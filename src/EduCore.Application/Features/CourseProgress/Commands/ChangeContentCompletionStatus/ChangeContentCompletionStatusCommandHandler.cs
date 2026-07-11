using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.CourseProgress.Commands.ChangeContentCompletionStatus;

public sealed class ChangeContentCompletionStatusCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork, ICourseProgressService courseProgressService) : IRequestHandler<ChangeContentCompletionStatusCommand, Result>
{
    public async Task<Result> Handle(ChangeContentCompletionStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();

        // Check If Content Exists Or Not
        var content = await unitOfWork.Contents.GetTableNoTracking().Include(c => c.Section).ThenInclude(s => s.Course)
            .FirstOrDefaultAsync(c => c.Id == request.ContentId);
        if (content == null)
            return Errors.ContentNotFound;

        // Check if user enrolled in course
        var enrollment = await unitOfWork.Enrollments.GetTableAsTracking().FirstOrDefaultAsync(e => e.UserId == user.Id && e.CourseId == content.Section.CourseId);
        if (enrollment == null) 
            return Errors.NotEnrolledInCourse;

        var ProgressStatus = await unitOfWork.UserCourseProgresses.GetTableAsTracking()
            .FirstOrDefaultAsync(p => p.UserId == user.Id && p.ContentId == request.ContentId);
        if (ProgressStatus == null)
        {
            ProgressStatus = new UserCourseProgress
            { UserId = user.Id, ContentId = content.Id, IsCompleted = request.IsCompleted, CompletedAt = request.IsCompleted ? DateTime.UtcNow : null };
            await unitOfWork.UserCourseProgresses.AddAsync(ProgressStatus);
        }
        else
        {
            ProgressStatus.IsCompleted = request.IsCompleted;
            ProgressStatus.CompletedAt = request.IsCompleted ? DateTime.UtcNow : null;
        }
        if (await courseProgressService.IsCompletedFullCourse(content.Section.Course))
        {
            enrollment.CourseCompletionAt = DateTime.UtcNow;
        }
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
