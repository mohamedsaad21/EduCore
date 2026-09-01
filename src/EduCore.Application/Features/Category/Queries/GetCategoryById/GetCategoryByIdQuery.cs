using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Category.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<Result<GetCategoryByIdResponse>>;