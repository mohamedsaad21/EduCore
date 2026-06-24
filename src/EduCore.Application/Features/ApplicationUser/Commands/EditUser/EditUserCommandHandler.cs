using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.EditUser;

public sealed class EditUserCommandHandler(UserManager<User> userManager, IMapper mapper, IFileService fileService) : IRequestHandler<EditUserCommand, Result>
{
    public async Task<Result> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var oldUser = await userManager.FindByIdAsync(request.Id.ToString());
        if (oldUser == null) return Errors.UserNotFound;

        var newUser = mapper.Map(request, oldUser);
        // edit profile picture
        if (request.ProfilePicture != null)
        {
            if (newUser.ProfilePictureUrl != null)
            {
                await fileService.DeleteAsync(newUser.ProfilePicturePublicId, "Image");
            }
            var UploadResult = await fileService.UploadAsync(request.ProfilePicture);
            newUser.ProfilePictureUrl = UploadResult.Url;
            newUser.ProfilePicturePublicId = UploadResult.PublicId;
        }
        var result = await userManager.UpdateAsync(newUser);

        if (!result.Succeeded)
            return Errors.IdentityEditUserFailed;

        return Result.Success();
    }
}
