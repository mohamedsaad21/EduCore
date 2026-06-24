using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;
using EduCore.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.AddUser;

public sealed class AddUserCommandHandler(UserManager<User> userManager, IMapper mapper, IFileService fileService, IEmailService emailService) : IRequestHandler<AddUserCommand, Result>
{
    public async Task<Result> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        if (await userManager.FindByEmailAsync(user.Email) != null)
            return Errors.EmailAlreadyExists;

        if (await userManager.FindByNameAsync(user.UserName) != null)
            return Errors.UserNameAlreadyExists;

        var createResult = await userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded)
            return Errors.IdentityCreateUserFailed;

        await userManager.AddToRoleAsync(user, Roles.Student);

        // Email confirmation logic can be added here

        var random = new Random();

        var code = random.Next(1, 1000000).ToString("D6");

        user.Code = code;

        if (request.ProfilePicture != null)
        {
            var result = await fileService.UploadAsync(request.ProfilePicture);
            user.ProfilePictureUrl = result.Url;
            user.ProfilePicturePublicId = result.PublicId;
        }
        await userManager.UpdateAsync(user);

        var message = $"This code is to confirm your account {user.Code}";
        await emailService.SendEmailAsync(user.Email, message, "Confirm Account");
        //var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication",
        //    new { userId = User.Id, code = code });

        //var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";

        //await _emailService.SendEmailAsync(User.Email, message, "Email Confirmation");

        return Result.Success();
    }
}
