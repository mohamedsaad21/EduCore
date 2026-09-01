using EduCore.Application.Common.DTOs.Auth;
using EduCore.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace EduCore.Application.Abstracts;

public interface IAuthenticationService
{
    Task<JwtSecurityToken> CreateJwtToken(User user);
    Task<RefreshToken> CreateRefreshToken();
    Task<AuthResponse> GetJwtToken(User user);
    Task<AuthResponse> AuthenticateWithGoogleAsync(string idToken);
}
