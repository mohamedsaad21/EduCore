using EduCore.Domain.Common;

namespace EduCore.Domain.Entities;

public class CourseCategory : GeneralLocalizableEntity
{
    public CourseCategory()
    {
        Courses = new HashSet<Course>();
    }
    public string NameEn { get; set; }
    public string NameAr { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? ThumbnailPublicId { get; set; }
    public ICollection<Course> Courses { get; set; }
}
