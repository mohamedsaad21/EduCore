using EduCore.API.Base;
using EduCore.Application.Features.Authorization.Commands.AddRole;
using EduCore.Application.Features.Authorization.Commands.DeleteRole;
using EduCore.Application.Features.Authorization.Commands.EditRole;
using EduCore.Application.Features.Authorization.Commands.UpdateUserRoles;
using EduCore.Application.Features.Authorization.Queries.GetRoleById;
using EduCore.Application.Features.Authorization.Queries.GetRolesList;
using EduCore.Application.Features.Authorization.Queries.ManageUserRoles;
using EduCore.Domain.AppMetaData;
using EduCore.Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

[Authorize(Roles = Roles.Admin)]
public class AuthorizationController : AppControllerBase
{
    [HttpGet(Router.AuthorizationRouting.List)]
    public async Task<IActionResult> GetAllRoles()
    {
        return ToActionResult(await Mediator.Send(new GetRolesListQuery()));
    }

    [HttpGet(Router.AuthorizationRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetRoleByIdQuery(Id)));
    }

    [HttpPost(Router.AuthorizationRouting.Create)]
    public async Task<IActionResult> Create([FromQuery] AddRoleCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpPut(Router.AuthorizationRouting.Edit)]
    public async Task<IActionResult> Edit([FromQuery] EditRoleCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpDelete(Router.AuthorizationRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteRoleCommand(Id)));
    }

    [HttpGet(Router.AuthorizationRouting.ManageUserRoles)]
    public async Task<IActionResult> ManageUserRoles([FromRoute] Guid userId)
    {
        return ToActionResult(await Mediator.Send(new ManageUserRolesQuery(userId)));
    }

    [HttpPut(Router.AuthorizationRouting.UpdateUserRoles)]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }
}
