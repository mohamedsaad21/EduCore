using EduCore.Application.Abstracts;
using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Sections.Commands.AddSection;

public class AddSectionCommandValidator : AbstractValidator<AddSectionCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISectionService _sectionService;
    public AddSectionCommandValidator(IStringLocalizer<SharedResources> stringLocalizer, ISectionService sectionService)
    {
        _stringLocalizer = stringLocalizer;
        _sectionService = sectionService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.Title).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);

        RuleFor(x => x.CourseId).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.Order).MustAsync(async (model, key, CancellationToken) => !await _sectionService.IsSectionOrderExists(model.CourseId, key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.OrderIsAlreadyExists]);

        RuleFor(x => x.Title).MustAsync(async (model, key, CancellationToken) => !await _sectionService.IsSectionTitleExists(model.CourseId, key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.TitleIsAlreadyExists]);
    }
}
