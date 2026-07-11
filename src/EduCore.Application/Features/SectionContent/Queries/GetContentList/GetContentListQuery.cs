using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.SectionContent.Queries.GetContentList;

public sealed record GetContentListQuery(Guid SectionId) : IRequest<Result<List<GetContentListResponse>>>;