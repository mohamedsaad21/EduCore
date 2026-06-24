using EduCore.Domain.Entities.Identity;

namespace EduCore.Application.Abstracts;

public interface ICurrentUserService
{
    Task<Guid> GetCurrentUserId();
    Task<User> GetCurrentUserAsync();
    Task<List<string>> GetCurrentUserRolesAsync();
}
