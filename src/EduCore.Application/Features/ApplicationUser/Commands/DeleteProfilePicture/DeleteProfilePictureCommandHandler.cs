using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.DeleteProfilePicture;

public sealed class DeleteProfilePictureCommandHandler(UserManager<User> userManager, ICurrentUserService currentUserService, IFileService fileService) : IRequestHandler<DeleteProfilePictureCommand, Result>
{
    public async Task<Result> Handle(DeleteProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await currentUserService.GetCurrentUserAsync();

        if (currentUser.ProfilePictureUrl == null)
            return Errors.NoProfilePictureExists;

        await fileService.DeleteAsync(currentUser.ProfilePicturePublicId, "Image");
        currentUser.ProfilePicturePublicId = null;
        currentUser.ProfilePictureUrl = null;
        await userManager.UpdateAsync(currentUser);
        return Result.Success();
    }
}
