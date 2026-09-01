namespace EduCore.Application.Features.SectionContent.Queries.GetContentList;

public class GetContentListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Duration { get; set; }
    public string Url { get; set; }
    public bool IsCompleted { get; set; }
    public Guid SectionId { get; set; }
}
