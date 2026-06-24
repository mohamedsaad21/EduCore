using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authorization.Queries.GetRoleById;

public sealed record GetRoleByIdQuery(Guid Id) : IRequest<Result<GetRoleByIdResponse>>;
