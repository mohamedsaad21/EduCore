using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Domain.Entities.Identity;

public class User : IdentityUser<Guid>
{
    public User()
    {
        RefreshTokens = new HashSet<RefreshToken>();
        Baskets = new HashSet<Basket>();
        Courses = new HashSet<Course>();
        Feedbacks = new HashSet<Feedback>();
    }
    public string FullName { get; set; }
    [EncryptColumn]
    public string? Code { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? ProfilePicturePublicId { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    public virtual ICollection<Basket> Baskets { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Feedback> Feedbacks { get; set; }
}
