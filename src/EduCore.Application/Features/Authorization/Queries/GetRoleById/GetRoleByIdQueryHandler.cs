using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Authorization.Queries.GetRoleById;

public sealed class GetRoleByIdQueryHandler(RoleManager<Role> roleManager, IMapper mapper) : IRequestHandler<GetRoleByIdQuery, Result<GetRoleByIdResponse>>
{
    public async Task<Result<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.Id);
        if (role == null)
            return Errors.RoleNotFound;

        var roleMapper = mapper.Map<GetRoleByIdResponse>(role);
        return roleMapper;
    }
}