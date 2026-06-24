using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Feedback.Commands.AddFeedback;

public sealed class AddFeedbackCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IEnrollmentService enrollmentService) : IRequestHandler<AddFeedbackCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddFeedbackCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();
        // Check if course exists or not
        var course = await unitOfWork.Courses.GetTableAsTracking().FirstOrDefaultAsync(c => c.Id == request.CourseId);
        if (course == null)
            return Errors.CourseNotFound;
        // Check if user enrolled in course
        var Enrolled = await enrollmentService.CheckEnrollmentAsync(course, user);
        if (!Enrolled) 
            return Errors.NotEnrolledInCourse;

        // Check that there isn't duplicate rating to the same course
        if (await unitOfWork.Feedbacks.GetTableNoTracking().AnyAsync(f => f.UserId == user.Id && f.CourseId == course.Id))
            return Errors.AlreadyGiveFeedback;

        var feedback = new Domain.Entities.Feedback { UserId = user.Id, CourseId = course.Id, Rating = request.Rating, Comment = request.Comment == "" ? null : request.Comment };
        await unitOfWork.Feedbacks.AddAsync(feedback);
        // Update Average Rating & Rating Count int Course
        var query = unitOfWork.Feedbacks.GetTableNoTracking().Where(f => f.CourseId == course.Id);
        var SumOfRatings = await query.SumAsync(f => f.Rating);
        var RatingCount = await query.CountAsync();

        course.RatingCount = RatingCount;
        course.AverageRating = (double)SumOfRatings / course.RatingCount;

        await unitOfWork.SaveChangesAsync();
        return feedback.Id;
    }
}
