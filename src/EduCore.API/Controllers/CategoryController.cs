using EduCore.API.Base;
using EduCore.Application.Features.Category.Commands.DeleteCategory;
using EduCore.Application.Features.Category.Commands.EditCategory;
using EduCore.Application.Features.Category.Queries.GetCategoriesList;
using EduCore.Application.Features.Category.Queries.GetCategoryById;
using EduCore.Core.Features.Category.Commands.Models;
using EduCore.Domain.AppMetaData;
using EduCore.Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class CategoryController : AppControllerBase
{

    [HttpGet(Router.CategoryRouting.List)]
    public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.CategoryRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetCategoryByIdQuery(Id)));
    }
    [Authorize(Roles = Roles.Admin)]
    [HttpPost(Router.CategoryRouting.Create)]
    public async Task<IActionResult> CreateCategory([FromForm] AddCategoryCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut(Router.CategoryRouting.Edit)]
    public async Task<IActionResult> EditCategory([FromForm] EditCategoryCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete(Router.CategoryRouting.Delete)]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteCategoryCommand(Id)));
    }

}
