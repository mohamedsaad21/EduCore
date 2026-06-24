using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authorization.Queries.GetRolesList;

public sealed record GetRolesListQuery() : IRequest<Result<List<GetRolesListResponse>>>;