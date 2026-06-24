using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Category.Queries.GetCategoriesList;

public sealed class GetCategoriesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCategoriesListQuery, Result<List<GetCategoriesListResponse>>>
{
    public async Task<Result<List<GetCategoriesListResponse>>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var List = await unitOfWork.Categories.GetTableNoTracking().ToListAsync();
        var ListMapper = mapper.Map<List<GetCategoriesListResponse>>(List);
        return ListMapper;
    }
}
