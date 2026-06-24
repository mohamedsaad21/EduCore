namespace EduCore.Domain.Helpers;

public class AuthResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string ProfilePictureUrl { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }
    public DateTime ExpiresAt {  get; set; }
}
