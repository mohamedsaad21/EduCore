using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.SectionContent.Queries.GetContentById;

public sealed record GetContentByIdQuery(Guid Id) : IRequest<Result<GetContentByIdResponse>>;