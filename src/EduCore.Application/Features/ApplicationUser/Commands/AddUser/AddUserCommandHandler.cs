using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Constants;
using EduCore.Domain.Entities;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.AddUser;

public sealed class AddUserCommandHandler(UserManager<User> userManager, IMapper mapper, IFileService fileService, IEmailService emailService, IUnitOfWork unitOfWork) : IRequestHandler<AddUserCommand, Result>
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
            var result = await fileService.UploadRawFileAsync(request.ProfilePicture);
            user.ProfilePictureUrl = result.Url;
            user.ProfilePicturePublicId = result.PublicId;
        }
        var basket = new Domain.Entities.Basket
        {
            CustomerId = user.Id,
            CreatedAt = DateTime.UtcNow,
        };
        await userManager.UpdateAsync(user);
        await unitOfWork.Baskets.AddAsync(basket);
        basket.BasketItems = new List<BasketItem>();
        await unitOfWork.SaveChangesAsync();
        var message = $"This code is to confirm your account {user.Code}";
        await emailService.SendEmailAsync(user.Email, message, "Confirm Account");
        //var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication",
        //    new { userId = User.Id, code = code });

        //var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";

        //await _emailService.SendEmailAsync(User.Email, message, "Email Confirmation");

        return Result.Success();
    }
}
