namespace EduCore.Application.Abstracts;

public interface IAuthorizationService
{
    Task<bool> IsRoleExistsAsync(string roleName);
    Task<bool> IsRoleExistsExcludeSelfAsync(Guid Id, string roleName);
}
