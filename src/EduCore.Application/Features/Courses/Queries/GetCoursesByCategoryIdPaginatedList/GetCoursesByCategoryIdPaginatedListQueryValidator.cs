using EduCore.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByCategoryIdPaginatedList;

public class GetCoursesByCategoryIdPaginatedListQueryValidator : AbstractValidator<GetCoursesByCategoryIdPaginatedListQuery>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public GetCoursesByCategoryIdPaginatedListQueryValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
    }
}
