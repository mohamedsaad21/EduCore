using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.CourseProgress.Commands.ChangeContentCompletionStatus;

public class ChangeContentCompletionStatusCommandValidator : AbstractValidator<ChangeContentCompletionStatusCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public ChangeContentCompletionStatusCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.ContentId).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
}
