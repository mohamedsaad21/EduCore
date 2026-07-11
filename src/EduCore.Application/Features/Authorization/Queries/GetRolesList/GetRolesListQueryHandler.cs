using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Authorization.Queries.GetRolesList;

public sealed class GetRolesListQueryHandler(RoleManager<Role> roleManager, IMapper mapper) : IRequestHandler<GetRolesListQuery, Result<List<GetRolesListResponse>>>
{
    public async Task<Result<List<GetRolesListResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await roleManager.Roles.ToListAsync();
        var rolesMapper = mapper.Map<List<GetRolesListResponse>>(roles);
        return rolesMapper;
    }
}
