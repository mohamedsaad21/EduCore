using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionById;

public sealed record GetCourseSectionByIdQuery(Guid Id) : IRequest<Result<GetCourseSectionByIdResponse>>;
