using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Feedback.Commands.EditFeedback;

public sealed class EditFeedbackCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditFeedbackCommand, Result>
{
    public async Task<Result> Handle(EditFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await unitOfWork.Feedbacks.GetTableAsTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (feedback == null)
            return Errors.FeedbackNotFound;

        feedback.Rating = request.Rating;
        feedback.Comment = request.Comment == "" ? null : request.Comment;

        var course = await unitOfWork.Courses.GetTableAsTracking().FirstOrDefaultAsync(c => c.Id == feedback.CourseId);
        var query = unitOfWork.Feedbacks.GetTableNoTracking().Where(f => f.CourseId == course.Id);

        course.RatingCount = await query.CountAsync();
        var SumOfRatings = await query.SumAsync(f => f.Rating);
        course.AverageRating = (double)SumOfRatings / course.RatingCount;

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
