using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace EduCore.Application.Abstracts;

public interface IAuthenticationService
{
    /// <summary>
    /// Generates a JSON Web Token (JWT) for the specified user asynchronously.
    /// </summary>
    /// <param name="user">The user for whom the JWT will be created. Must contain valid user identification and claims required for
    /// token generation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the generated JWT as a string.</returns>
    Task<JwtSecurityToken> CreateJwtToken(User user);

    /// <summary>
    /// Generates a new refresh token for use in authentication workflows.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the newly created <see
    /// cref="RefreshToken"/> instance.</returns>
    Task<RefreshToken> CreateRefreshToken();
    Task<AuthResponse> GetJwtToken(User user);
    Task<AuthResponse> AuthenticateWithGoogleAsync(string idToken);

}
