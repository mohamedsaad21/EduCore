using EduCore.Application.Features.Authorization.Queries.ManageUserRoles;

namespace EduCore.Domain.Results;

public class ManageUserRolesResponse
{
    public Guid UserId { get; set; }
    public List<UserRoleResponse> Roles { get; set; }
}
