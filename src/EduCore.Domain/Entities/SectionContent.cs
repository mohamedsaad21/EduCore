namespace EduCore.Domain.Entities;

public class SectionContent : BaseEntity
{
    public SectionContent()
    {
        UserCourseProgress = new HashSet<UserCourseProgress>();
    }
    public string Title { get; set; }
    public int Duration { get; set; }
    public string Url { get; set; }
    public string PublicId { get; set; }
    public string ResourceType { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public ICollection<UserCourseProgress> UserCourseProgress { get; set; }
}
