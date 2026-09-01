using EduCore.Application.Bases;
using EduCore.Domain.Results;
using MediatR;

namespace EduCore.Application.Features.Authorization.Queries.ManageUserRoles;

public sealed record ManageUserRolesQuery(Guid UserId) : IRequest<Result<ManageUserRolesResponse>>;