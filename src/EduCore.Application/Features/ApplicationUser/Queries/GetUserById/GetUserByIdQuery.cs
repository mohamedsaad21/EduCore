using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ApplicationUser.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<Result<GetUserByIdResponse>>;