namespace EduCore.Application.Features.ApplicationUser.Queries.GetUsersPaginatedList;

public class GetUsersPaginatedListResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string ProfilePictureUrl { get; set; }

    public GetUsersPaginatedListResponse(Guid id, string fullName, string userName, string email, string profilePictureUrl)
    {
        Id = id;
        FullName = fullName;
        UserName = userName;
        Email = email;
        ProfilePictureUrl = profilePictureUrl;
    }
}
