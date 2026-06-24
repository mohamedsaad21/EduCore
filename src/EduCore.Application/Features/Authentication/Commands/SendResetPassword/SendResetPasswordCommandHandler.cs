using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authentication.Commands.SendResetPassword;

public sealed class SendResetPasswordCommandHandler(UserManager<User> userManager, IEmailService emailService) : IRequestHandler<SendResetPasswordCommand, Result>
{
    public async Task<Result> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return Errors.UserNotFound;

        var random = new Random();

        var code = random.Next(1, 1000000).ToString("D6");

        user.Code = code;
        await userManager.UpdateAsync(user);

        var message = $"This code to reset password: {code}";
        await emailService.SendEmailAsync(user.Email, message, "Reset Password");

        return Result.Success();        
    }
}
