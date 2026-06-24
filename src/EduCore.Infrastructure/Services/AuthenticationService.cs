using EduCore.Application.Abstracts;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EduCore.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly IConfiguration _configuration;
    public AuthenticationService(UserManager<User> userManager, JwtSettings jwtSettings, IConfiguration configuration)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _configuration = configuration;
    }

    public async Task<JwtSecurityToken> CreateJwtToken(User user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim("role", role));

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id.ToString())
        }.Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: signingCredentials,
            expires:DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes)
            );

        return jwtSecurityToken;
    }

    public async Task<AuthResponse> GetJwtToken(User user)
    {
        var authResponse = new AuthResponse();

        if (user.RefreshTokens.Any(t => t.IsActive))
        {
            var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
            authResponse.RefreshToken = activeRefreshToken.Token;
            authResponse.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
        }
        else
        {
            var refreshToken = await CreateRefreshToken();
            authResponse.RefreshToken = refreshToken.Token;
            authResponse.RefreshTokenExpiration = refreshToken.ExpiresOn;
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);
        }

        var jwtSecurityToken = await CreateJwtToken(user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        var roles = await _userManager.GetRolesAsync(user);
        authResponse.Id = user.Id;
        authResponse.FullName = user.FullName;
        authResponse.UserName = user.UserName;
        authResponse.Email = user.Email;
        authResponse.ProfilePictureUrl = user.ProfilePictureUrl;
        authResponse.Roles = roles.ToList();
        authResponse.Token = accessToken;
        authResponse.ExpiresAt = jwtSecurityToken.ValidTo;
        return authResponse;
    }

    public async Task<RefreshToken> CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var generator = new RNGCryptoServiceProvider(randomNumber);
        generator.GetBytes(randomNumber);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomNumber),
            CreatedOn = DateTime.UtcNow,
            ExpiresOn = DateTime.UtcNow.AddDays(30)
        };

    }
    public async Task<AuthResponse> AuthenticateWithGoogleAsync(string idToken)
    {
        // Validate the ID token and retrieve the payload
        var payload = await ValidateGoogleTokenAsync(idToken);

        // Check if the user already exists in the database
        var user = await _userManager.FindByEmailAsync(payload.Email);

        // If user doesn't exist, throw UnauthorizedAccessException
        if (user == null)
        {
            user = new User
            {
                Email = payload.Email,
                UserName = payload.Email,
                FullName = payload.Name,
                ProfilePictureUrl = payload.Picture,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed: {errors}");
            }

            await _userManager.AddToRoleAsync(user, Roles.Student);
        }

        // Get a token
        var authResponse = await GetJwtToken(user);
        return authResponse;
    }

    private async Task<GoogleJsonWebSignature.Payload> ValidateGoogleTokenAsync(string idToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { _configuration["Authentication:Google:ClientId"] }
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

        if (payload == null || string.IsNullOrEmpty(payload.Email))
            throw new UnauthorizedAccessException("Invalid Google Token");

        return payload;
    }
}
