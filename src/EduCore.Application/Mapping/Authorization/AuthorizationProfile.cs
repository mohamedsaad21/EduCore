using AutoMapper;

namespace EduCore.Core.Mapping.Authorization;

public partial class AuthorizationProfile : Profile
{
    public AuthorizationProfile()
    {
        GetRolesListQueryMapping();
        GetRoleByIdQueryMapping();
    }
}
