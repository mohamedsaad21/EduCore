using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Feedback.Commands.EditFeedback;

public class EditFeedbackCommandValidator : AbstractValidator<EditFeedbackCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public EditFeedbackCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

        RuleFor(x => x.CourseId).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

        RuleFor(x => x.Rating).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
        .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.Rating).MustAsync(async (model, key, CancellationToken) => key >= 1 && key <= 5)
            .WithMessage(_stringLocalizer[SharedResourcesKeys.RatingMustBeBetween1And5]);
    }
}