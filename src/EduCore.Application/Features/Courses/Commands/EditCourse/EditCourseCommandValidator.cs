using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Courses.Commands.EditCourse;

public class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public EditCourseCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
    }
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

        RuleFor(x => x.Title).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

        RuleFor(x => x.Description).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
        .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
        .MinimumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MinLength100Character])
        .MaximumLength(500).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength500Character]);


        RuleFor(x => x.Price).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
        .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
        .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.MustBePositive]);

        RuleFor(x => x.CategoryId).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
        .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
}