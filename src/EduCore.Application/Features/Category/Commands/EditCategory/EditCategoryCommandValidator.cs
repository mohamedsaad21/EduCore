using EduCore.Application.Abstracts;
using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Application.Features.Category.Commands.EditCategory;

public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ICategoryService _categoryService;

    public EditCategoryCommandValidator(IStringLocalizer<SharedResources> stringLocalizer, ICategoryService categoryService)
    {
        _stringLocalizer = stringLocalizer;
        _categoryService = categoryService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.NameEn).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.NameEn).MustAsync(async (model, key, CancellationToken) => !await _categoryService.IsExistsExcludeSelfAsync(model.Id, key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.CategoryAlreadyExists]);
    }
}