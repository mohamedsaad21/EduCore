using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ApplicationUser.Commands.DeleteProfilePicture;

public sealed record DeleteProfilePictureCommand() : IRequest<Result<string>>;
