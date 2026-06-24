using EduCore.Domain.Entities.Identity;

namespace EduCore.Domain.Entities;

public class Feedback : DatedEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
