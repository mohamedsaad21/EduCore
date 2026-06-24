using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Feedback.Commands.DeleteFeedback;

public sealed class DeleteFeedbackCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteFeedbackCommand, Result>
{
    public async Task<Result> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await unitOfWork.Feedbacks.GetTableAsTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (feedback == null)
            return Errors.FeedbackNotFound;

        await unitOfWork.Feedbacks.DeleteAsync(feedback);
        var course = await unitOfWork.Courses.GetTableAsTracking().FirstOrDefaultAsync(c => c.Id == feedback.CourseId);

        var query = unitOfWork.Feedbacks.GetTableNoTracking().Where(f => f.CourseId == course.Id);

        course.RatingCount = await query.CountAsync();

        if (course.RatingCount == 0)
        {
            course.AverageRating = 0;
        }
        else
        {
            var SumOfRatings = await query.SumAsync(f => f.Rating);
            course.AverageRating = (double)SumOfRatings / course.RatingCount;
        }

        await unitOfWork.SaveChangesAsync();
        return Result.Success();

    }
}
