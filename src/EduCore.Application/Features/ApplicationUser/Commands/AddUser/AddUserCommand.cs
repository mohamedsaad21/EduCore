using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.ApplicationUser.Commands.AddUser;

public sealed record AddUserCommand
    (
        string FullName,
        string UserName,
        string Email,
        string Password,
        string ConfirmPassword,
        IFormFile? ProfilePicture
    ) : IRequest<Result>;