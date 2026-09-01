using EduCore.Application.Features.ApplicationUser.Commands.EditUser;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Core.Mapping.ApplicationUser;

public partial class ApplicationUserProfile
{
    public void UpdateUserCommandMapping()
    {
        CreateMap<EditUserCommand, User>();
    }
}
