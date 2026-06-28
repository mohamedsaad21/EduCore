using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Interfaces;
using MediatR;

namespace EduCore.Application.Features.Category.Queries.GetCategoriesList;

public sealed class GetCategoriesPaginatedListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCategoriesPaginatedListQuery, Result<PaginatedResult<GetCategoriesPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCategoriesPaginatedListResponse>>> Handle(GetCategoriesPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var categories = unitOfWork.Categories.GetTableNoTracking();
        if (!string.IsNullOrEmpty(request.Search))
        {
            categories = categories.Where(x => x.NameAr.Contains(request.Search) || x.NameEn.Contains(request.Search));
        }
        var result = await categories.Select(x => mapper.Map<GetCategoriesPaginatedListResponse>(x)).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return result;
    }
}
