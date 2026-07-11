using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Category.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdResponse>>
{
    public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (category == null)
            return Errors.CategoryNotFound;

        var categoryResponse = mapper.Map<GetCategoryByIdResponse>(category);
        return categoryResponse;
    }
}
