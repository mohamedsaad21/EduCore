using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Core.Features.Courses.Commands.AddCourse;

public sealed class AddCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService, IFileService fileService) : IRequestHandler<AddCourseCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetTableAsTracking().FirstOrDefaultAsync(x => x.Id == request.CategoryId);

        if (category == null)
            return Errors.CategoryNotFound;

        var imgCreateResult = await fileService.UploadRawFileAsync(request.Thumbnail);
        if (imgCreateResult.Message == "NoFile") return Errors.NoFile;
        if (imgCreateResult.Message == "FailedToUploadImage") return Errors.FailedToUploadFile;

        var course = mapper.Map<Course>(request);
        course.ThumbnailUrl = imgCreateResult.Url;
        course.ThumbnailPublicId = imgCreateResult.PublicId;
        //Get Instructor ID
        var InstructorId = await currentUserService.GetCurrentUserId();
        course.InstructorId = InstructorId;
        if (request.Objectives != null && request.Objectives.Count > 0)
        {
            foreach (var obj in request.Objectives)
                course.CourseObjectives.Add(new CourseObjective
                {
                    Text = obj,
                });
        }
        await unitOfWork.Courses.AddAsync(course);
        category.NoOfCourses++;
        await unitOfWork.SaveChangesAsync();
        return course.Id;
    }
}
