using EduCore.Domain.Entities;
using QuestPDF.Infrastructure;

namespace EduCore.Application.Abstracts;

public interface ICertificateService
{
    Task<IDocument> GenerateCertificateAsync(Course Course);
}
