using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EduCore.Infrastructure.Services;

public class CertificateService : ICertificateService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IEnrollmentService _enrollmentService;

    public CertificateService(ICurrentUserService currentUserService, IEnrollmentService enrollmentService)
    {
        _currentUserService = currentUserService;
        _enrollmentService = enrollmentService;
    }

    public async Task<IDocument> GenerateCertificateAsync(Course Course)
    {
        var user = await _currentUserService.GetCurrentUserAsync();
        var enrollment = (await _enrollmentService.GetUserEnrollmentsListAsync()).FirstOrDefault(e => e.UserId == user.Id && e.CourseId == Course.Id);
        return Document.Create(container =>
            {
                container.Page(page =>
                {
                    // Certificate Landscape 
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(50);
                    page.PageColor(Colors.Grey.Lighten5);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Content
                    page.Content().Column(column =>
                    {
                        // Header
                        column.Item().Row(row =>
                        {
                            // Logo
                            row.RelativeItem().AlignLeft().Column(col =>
                            {
                                col.Item().Text("EduCore")
                                    .FontSize(40)
                                    .Bold()
                                    .FontColor(Colors.Black);
                            });
                        });

                        column.Item().PaddingTop(60);

                        // "CERTIFICATE OF COMPLETION"
                        column.Item()
                            .PaddingBottom(15)
                            .Text("CERTIFICATE OF COMPLETION")
                            .FontSize(13)
                            .FontColor("#757575")
                            .FontFamily("Arial")
                            .Medium();

                        column.Item().PaddingTop(30);

                        // Course Info
                        column.Item().Text(Course.Title)
                            .FontSize(48)
                            .Bold()
                            .FontColor(Colors.Black)
                            .LineHeight(1.2f);

                        column.Item().PaddingTop(20);

                        // Instructor Info
                        column.Item().Text(text =>
                        {
                            text.Span("Instructor  ")
                                .FontSize(14)
                                .FontColor(Colors.Grey.Darken2);
                            text.Span(Course.Instructor.FullName)
                                .FontSize(14)
                                .Bold()
                                .FontColor(Colors.Grey.Darken2);
                        });

                        column.Item().PaddingTop(100);

                        // Student
                        column.Item().Text(user.FullName)
                            .FontSize(52)
                            .Bold()
                            .FontColor(Colors.Black);

                        column.Item().PaddingTop(30);

                        // Date Of Completion
                        column.Item().Row(row =>
                        {
                            row.ConstantItem(150).Column(col =>
                            {
                                col.Item().Text("Date")
                                    .FontSize(11)
                                    .SemiBold()
                                    .FontColor(Colors.Grey.Darken2);
                                col.Item().PaddingTop(3);
                                col.Item().Text(enrollment?.CourseCompletionAt?.ToString("MMM. d, yyyy"))
                                    .FontSize(11)
                                    .FontColor(Colors.Grey.Darken2);
                            });

                            row.ConstantItem(20);

                            // Course Duration
                            row.ConstantItem(150).Column(col =>
                            {
                                col.Item().Text("Length")
                                    .FontSize(11)
                                    .SemiBold()
                                    .FontColor(Colors.Grey.Darken2);
                                col.Item().PaddingTop(3);
                                col.Item().Text($"{Course.TotalHours} total hours")
                                    .FontSize(11)
                                    .FontColor(Colors.Grey.Darken2);
                            });

                            row.RelativeItem();
                        });
                    });
                });
            }
        );
    }
}
