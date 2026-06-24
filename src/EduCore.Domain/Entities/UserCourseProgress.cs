using EduCore.Domain.Entities.Identity;

namespace EduCore.Domain.Entities;

public class UserCourseProgress : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid ContentId { get; set; }
    public SectionContent Content { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
}
