using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Category.Queries.GetCategoriesList;

public sealed record GetCategoriesListQuery : IRequest<Result<List<GetCategoriesListResponse>>>;