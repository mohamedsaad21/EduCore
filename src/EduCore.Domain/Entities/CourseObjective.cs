namespace EduCore.Domain.Entities;

public class CourseObjective
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}
