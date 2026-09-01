using EduCore.Application.Abstracts;
using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Authorization.Commands.AddRole;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IAuthorizationService _authorizationService;

    public AddRoleCommandValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
    {
        _stringLocalizer = stringLocalizer;
        _authorizationService = authorizationService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.Role).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.Role).MustAsync(async (model, key, CancellationToken) => !await _authorizationService.IsRoleExistsAsync(key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleAlreadyExists]);
    }
}
