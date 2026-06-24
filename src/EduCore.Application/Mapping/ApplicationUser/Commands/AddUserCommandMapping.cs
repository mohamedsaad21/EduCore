using EduCore.Application.Features.ApplicationUser.Commands.AddUser;
using EduCore.Domain.Entities.Identity;

namespace EduCore.Core.Mapping.ApplicationUser;

public partial class ApplicationUserProfile
{
    public void AddUserCommandMapping()
    {
        CreateMap<AddUserCommand, User>();
    }
}
