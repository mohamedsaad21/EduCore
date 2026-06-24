namespace EduCore.Application.Features.SectionContent.Queries.GetContentList;

public class GetContentListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public double Duration { get; set; }
    public string Url { get; set; }
    public string Category { get; set; }
    public string PublicId { get; set; }
    public Guid SectionId { get; set; }
}
