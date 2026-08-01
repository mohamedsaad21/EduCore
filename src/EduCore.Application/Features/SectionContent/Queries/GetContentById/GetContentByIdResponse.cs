namespace EduCore.Application.Features.SectionContent.Queries.GetContentById;

public class GetContentByIdResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Duration { get; set; }
    public string Url { get; set; }
    public string Category { get; set; }
    public string PublicId { get; set; }
    public Guid SectionId { get; set; }
}
