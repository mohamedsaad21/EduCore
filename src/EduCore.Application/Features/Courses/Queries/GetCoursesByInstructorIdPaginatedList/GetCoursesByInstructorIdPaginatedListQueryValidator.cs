using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;

public class GetCoursesByInstructorIdPaginatedListQueryValidator : AbstractValidator<GetCoursesByInstructorIdPaginatedListQuery>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public GetCoursesByInstructorIdPaginatedListQueryValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.InstructorId).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
}
