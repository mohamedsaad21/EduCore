using EduCore.Application.Features.ApplicationUser.Queries.GetUserById;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Core.Mapping.ApplicationUser;

public partial class ApplicationUserProfile
{
    public void GetUserByIdMapping()
    {
        CreateMap<User, GetUserByIdResponse>();
    }
}
