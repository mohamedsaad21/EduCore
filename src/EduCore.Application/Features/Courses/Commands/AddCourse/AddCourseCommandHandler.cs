using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;

namespace EduCore.Core.Features.Courses.Commands.AddCourse;

public sealed class AddCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService, IFileService fileService) : IRequestHandler<AddCourseCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        var course = mapper.Map<Course>(request);
        //Get Instructor ID
        var InstructorId = await currentUserService.GetCurrentUserId();
        course.InstructorId = InstructorId;

        await unitOfWork.Courses.AddAsync(course);

        var imgCreateResult = await fileService.UploadAsync(request.Thumbnail);
        if (imgCreateResult.Message == "NoFile") return Errors.NoFile;
        if (imgCreateResult.Message == "FailedToUploadImage") return Errors.FailedToUploadFile;
        course.Thumbnail = imgCreateResult.Url;
        course.ThumbnailPublicId = imgCreateResult.PublicId;
        await unitOfWork.SaveChangesAsync();
        return course.Id;
    }
}
