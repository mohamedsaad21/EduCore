using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Feedback.Queries.GetCourseFeedbackPaginatedList;

public sealed class GetCourseFeedbackPaginatedListQueryHandler(IUnitOfWork unitOfWork, ICourseService courseService, UserManager<User> userManager) : IRequestHandler<GetCourseFeedbackPaginatedListQuery, Result<PaginatedResult<GetCourseFeedbackPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCourseFeedbackPaginatedListResponse>>> Handle(GetCourseFeedbackPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var course = await courseService.GetByIdAsync(request.CourseId);
        if (course == null) return Errors.CourseNotFound;

        var FilterQuery = unitOfWork.Feedbacks.GetTableNoTracking().Where(f => f.CourseId == course.Id)
            .Join(userManager.Users, f => f.UserId, u => u.Id, (f, u) => new GetCourseFeedbackPaginatedListResponse
            {
                UserId = u.Id,
                UserName = u.UserName,
                Rating = f.Rating,
                Comment = f.Comment,
                CreatedAt = f.CreatedAt,
                UpdatedAt = f.UpdatedAt,
            });

        switch (request.OrderBy)
        {
            case FeedbackOrderingEnum.Rating: FilterQuery.OrderBy(f => f.Rating); break;
        }

        if (!string.IsNullOrEmpty(request.Search))
        {
            FilterQuery = FilterQuery.Where(f => f.UserName.Contains(request.Search) || f.Comment.Contains(request.Search));
        }
        var PaginatedList = await FilterQuery.ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return PaginatedList;
    }
}
