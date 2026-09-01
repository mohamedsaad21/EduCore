using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Category.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(Guid Id) : IRequest<Result>;