using MediatR;
using EduCore.Application.Bases;

namespace EduCore.Application.Features.SectionContent.Queries.GetContentPreviewList;

public sealed record GetContentPreviewListQuery(Guid SectionId) : IRequest<Result<List<GetContentPreviewListResponse>>>;
