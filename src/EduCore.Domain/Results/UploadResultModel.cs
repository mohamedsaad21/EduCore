namespace EduCore.Domain.Results;

public class UploadResultModel
{
    public string Url { get; set; }
    public string PublicId { get; set; }
    public string ResourceType { get; set; }
    public int Duration { get; set; }
    public string Message { get; set; }
}
