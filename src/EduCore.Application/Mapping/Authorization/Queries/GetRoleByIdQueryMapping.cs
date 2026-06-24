using EduCore.Application.Features.Authorization.Queries.GetRoleById;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Core.Mapping.Authorization;

public partial class AuthorizationProfile
{
    public void GetRoleByIdQueryMapping()
    {
        CreateMap<Role, GetRoleByIdResponse>();
    }
}
