using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.ApplicationUser.Commands.EditUser;

public sealed record EditUserCommand
(
    Guid Id,
    string FullName,
    string UserName,
    string? PhoneNumber,
    IFormFile? ProfilePicture
) : IRequest<Result>;
