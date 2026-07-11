using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EduCore.Core.Features.Certificate.Queries.GetCourseCertificate;

public sealed class GetCourseCertificateQueryHandler : IRequestHandler<GetCourseCertificateQuery, Result<FileContentResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICertificateService _certificateService;
    private readonly IEnrollmentService _enrollmentService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICourseProgressService _courseProgressService;

    public GetCourseCertificateQueryHandler(IUnitOfWork unitOfWork, ICertificateService certificateService, IEnrollmentService enrollmentService, 
        ICurrentUserService currentUserService, ICourseProgressService courseProgressService)
    {
        _unitOfWork = unitOfWork;
        _certificateService = certificateService;
        _enrollmentService = enrollmentService;
        _currentUserService = currentUserService;
        _courseProgressService = courseProgressService;
    }

    public async Task<Result<FileContentResult>> Handle(GetCourseCertificateQuery request, CancellationToken cancellationToken)
    {
        var user = await _currentUserService.GetCurrentUserAsync();
        // Check if course exists or not
        var course = await _unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.CourseId);
        if (course == null) return Errors.CourseNotFound;

        // Check if user enrolled in course
        var Enrolled = await _enrollmentService.CheckEnrollmentAsync(course, user);

        if (!Enrolled) return Errors.NotEnrolledInCourse;

        // Check if user completed course with percent 100%
        var Completed = await _courseProgressService.IsCompletedFullCourse(course);

        if(!Completed) return Errors.NotCompletedFullCourse;

        var GeneratedCertificate = await _certificateService.GenerateCertificateAsync(course);

        QuestPDF.Settings.License = LicenseType.Community;
        var document = GeneratedCertificate;
        var pdf = document.GeneratePdf();

        var result = new FileContentResult(pdf, "application/pdf")
        {
            FileDownloadName = $"{course.Title}-Certificate"
        };
        return result;
    }
}