using EduCore.Application.Abstracts;
using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.ApplicationUser.Commands.EditUser;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    private readonly IApplicationUserService _applicationUserService;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public EditUserCommandValidator(IStringLocalizer<SharedResources> stringLocalizer, IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.FullName).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

        RuleFor(x => x.UserName).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.UserName).MustAsync(async (model, key, CancellationToken) =>
        !await _applicationUserService.IsUserNameExistsExcludeSelfAsync(model.Id, key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.UserNameAlreadyExists]);
    }
}
