using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Authentication.Queries.ConfirmResetPassword;

public class ConfirmResetPasswordValidator : AbstractValidator<ConfirmResetPasswordQuery>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

public ConfirmResetPasswordValidator(IStringLocalizer<SharedResources> stringLocalizer)
{
    _stringLocalizer = stringLocalizer;
    ApplyValidationRules();
}

public void ApplyValidationRules()
{
    RuleFor(x => x.Email).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
        .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

    RuleFor(x => x.Code).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
}
