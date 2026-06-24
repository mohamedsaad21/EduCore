using EduCore.API.Base;
using EduCore.Application.Features.SectionContent.Commands.AddContent;
using EduCore.Application.Features.SectionContent.Commands.DeleteContent;
using EduCore.Application.Features.SectionContent.Commands.EditContent;
using EduCore.Application.Features.SectionContent.Queries.GetContentById;
using EduCore.Application.Features.SectionContent.Queries.GetContentList;
using EduCore.Core.Filters;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class ContentController : AppControllerBase
{
    [HttpGet(Router.ContentRouting.List)]
    public async Task<IActionResult> GetContentList([FromQuery] GetContentListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.ContentRouting.GetById)]
    public async Task<IActionResult> GetContentById([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetContentByIdQuery(Id)));
    }

    [ServiceFilter(typeof(AuthFilter))]
    [HttpPost(Router.ContentRouting.Create)]
    public async Task<IActionResult> CreateContent([FromForm] AddContentCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [ServiceFilter(typeof(AuthFilter))]
    [HttpPut(Router.ContentRouting.Edit)]
    public async Task<IActionResult> EditContent([FromForm] EditContentCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [ServiceFilter(typeof(AuthFilter))]
    [HttpDelete(Router.ContentRouting.Delete)]
    public async Task<IActionResult> DeleteContent([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteContentCommand(Id)));
    }
}
