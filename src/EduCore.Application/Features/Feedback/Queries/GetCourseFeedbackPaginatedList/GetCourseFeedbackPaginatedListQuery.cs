using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using MediatR;

namespace EduCore.Application.Features.Feedback.Queries.GetCourseFeedbackPaginatedList;

public sealed record GetCourseFeedbackPaginatedListQuery
    (
        Guid CourseId,
        int PageNumber,
        int PageSize,
        FeedbackOrderingEnum OrderBy,
        string? Search
    ) : IRequest<Result<PaginatedResult<GetCourseFeedbackPaginatedListResponse>>>;
