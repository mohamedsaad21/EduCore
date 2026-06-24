namespace EduCore.Application.Features.SectionContent.Queries.GetContentById;

public class GetContentByIdResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Duration { get; set; }
    public string Url { get; set; }
    public string Category { get; set; }
    public string PublicId { get; set; }
    public int SectionId { get; set; }
}
