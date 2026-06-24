using EduCore.API.Base;
using EduCore.Application.Features.Authentication.Commands.RefreshToken;
using EduCore.Application.Features.Authentication.Commands.ResetPassword;
using EduCore.Application.Features.Authentication.Commands.RevokeToken;
using EduCore.Application.Features.Authentication.Commands.SendResetPassword;
using EduCore.Application.Features.Authentication.Commands.SignIn;
using EduCore.Application.Features.Authentication.Queries.ConfirmEmail;
using EduCore.Application.Features.Authentication.Queries.ConfirmResetPassword;
using EduCore.Domain.AppMetaData;
using Fixy.Application.Features.Authentication.Commands.SignInWithGoogle;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class AuthenticationController : AppControllerBase
{
    [HttpPost(Router.AuthenticationRouting.SignIn)]
    public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost(Router.AuthenticationRouting.SignInWithGoogleAsync)]
    public async Task<IActionResult> SignInWithGoogleAsync([FromBody] SignInWithGoogleCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpPost(Router.AuthenticationRouting.RefreshToken)]
    public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpPost(Router.AuthenticationRouting.RevokeToken)]
    public async Task<IActionResult> RevokeToken([FromForm] RevokeTokenCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpGet(Router.AuthenticationRouting.ConfirmEmail)]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpPost(Router.AuthenticationRouting.SendResetPassword)]
    public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpGet(Router.AuthenticationRouting.ConfirmResetPassword)]
    public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpPost(Router.AuthenticationRouting.ResetPassword)]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }
}
