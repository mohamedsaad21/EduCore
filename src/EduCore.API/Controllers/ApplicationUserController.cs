using EduCore.API.Base;
using EduCore.Application.Features.ApplicationUser.Commands.AddInstructorRole;
using EduCore.Application.Features.ApplicationUser.Commands.AddUser;
using EduCore.Application.Features.ApplicationUser.Commands.ChangePassword;
using EduCore.Application.Features.ApplicationUser.Commands.DeleteProfilePicture;
using EduCore.Application.Features.ApplicationUser.Commands.DeleteUser;
using EduCore.Application.Features.ApplicationUser.Commands.EditUser;
using EduCore.Application.Features.ApplicationUser.Queries.GetUserById;
using EduCore.Application.Features.ApplicationUser.Queries.GetUsersPaginatedList;
using EduCore.Domain.AppMetaData;
using EduCore.Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

//[Authorize]
public class ApplicationUserController : AppControllerBase
{
    [Authorize(Roles = Roles.Admin)]
    [HttpGet(Router.ApplicationUserRouting.Paginated)]
    public async Task<IActionResult> GetUsersPaginatedList([FromQuery] GetUsersPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.ApplicationUserRouting.GetById)]
    public async Task<IActionResult> GetUsersPaginatedList([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetUserByIdQuery(Id)));
    }
    [AllowAnonymous]
    [HttpPost(Router.ApplicationUserRouting.Create)]
    public async Task<IActionResult> AddUser([FromForm] AddUserCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [Authorize(Roles = Roles.Student)]
    [HttpPut(Router.ApplicationUserRouting.Edit)]
    public async Task<IActionResult> UpdateUser([FromForm] EditUserCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpDelete(Router.ApplicationUserRouting.Delete)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteUserCommand(Id)));
    }
    [Authorize]
    [HttpDelete(Router.ApplicationUserRouting.DeleteProfilePicture)]
    public async Task<IActionResult> DeleteProfilePicture()
    {
        return ToActionResult(await Mediator.Send(new DeleteProfilePictureCommand()));
    }

    [Authorize(Roles = Roles.Student)]
    [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
    public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [Authorize(Roles = Roles.Student)]
    [HttpPost(Router.ApplicationUserRouting.AddInstructorRole)]
    public async Task<IActionResult> AddInstructorRole()
    {
        return ToActionResult(await Mediator.Send(new AddInstructorRoleCommand()));
    }
}
