using EduCore.Domain.Entities.Identity;

namespace EduCore.Domain.Entities
{
    public class Enrollment : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime EnrolledAt { get; set; } 
        public DateTime? CourseCompletionAt { get; set; }
    }
}
