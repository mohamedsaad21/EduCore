namespace EduCore.Domain.Entities
{
    public class Section : BaseEntity
    {
        public Section()
        {
            SectionContents = new HashSet<SectionContent>();
        }
        public string Title { get; set; }
        public int Order {  get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<SectionContent> SectionContents { get; set; }
    }
}
