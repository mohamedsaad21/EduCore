namespace EduCore.Application.Features.SectionContent.Queries.GetContentPreviewList;

public class GetContentPreviewListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Duration { get; set; }
    public string Category { get; set; }
    public Guid SectionId { get; set; }
}
