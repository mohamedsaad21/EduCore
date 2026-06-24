using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.ShoppingCart.Commands.DeleteFromCart;

public class DeleteFromCartCommandValidator : AbstractValidator<DeleteFromCartCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public DeleteFromCartCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.CourseId).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
}
