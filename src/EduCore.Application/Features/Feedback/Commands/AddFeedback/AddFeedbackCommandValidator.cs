using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Feedback.Commands.AddFeedback;

public class AddFeedbackCommandValidator : AbstractValidator<AddFeedbackCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public AddFeedbackCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
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