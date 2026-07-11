using EduCore.Application.Features.Authorization.Queries.GetRolesList;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Core.Mapping.Authorization;

public partial class AuthorizationProfile
{
    public void GetRolesListQueryMapping()
    {
        CreateMap<Role, GetRolesListResponse>();
    }
}
