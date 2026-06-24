using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Core.Features.Courses.Commands.AddCourse;

public class AddCourseCommandValidator :  AbstractValidator<AddCourseCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public AddCourseCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.Title).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

            RuleFor(x => x.Description).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

            RuleFor(x => x.Price).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.MustBePositive]);

            RuleFor(x => x.CategoryId).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

    }
}