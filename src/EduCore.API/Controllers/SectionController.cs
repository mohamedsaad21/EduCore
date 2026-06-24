using EduCore.API.Base;
using EduCore.Application.Features.Sections.Commands.AddSection;
using EduCore.Application.Features.Sections.Commands.DeleteSection;
using EduCore.Application.Features.Sections.Commands.EditSection;
using EduCore.Application.Features.Sections.Queries.GetCourseSectionById;
using EduCore.Application.Features.Sections.Queries.GetCourseSectionsPaginatedList;
using EduCore.Core.Filters;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class SectionController : AppControllerBase
{
    [HttpGet(Router.SectionRouting.Paginated)]
    public async Task<IActionResult> GetCourseSectionsPaginatedList([FromQuery] GetCourseSectionsPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.SectionRouting.GetById)]
    public async Task<IActionResult> GetCourseSectionById([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetCourseSectionByIdQuery(Id)));
    }


    [ServiceFilter(typeof(AuthFilter))]
    [HttpPost(Router.SectionRouting.Create)]
    public async Task<IActionResult> AddSection([FromBody] AddSectionCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [ServiceFilter(typeof(AuthFilter))]
    [HttpPut(Router.SectionRouting.Edit)]
    public async Task<IActionResult> EditSection([FromBody] EditSectionCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [ServiceFilter(typeof(AuthFilter))]
    [HttpDelete(Router.SectionRouting.Delete)]
    public async Task<IActionResult> DeleteSection([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteSectionCommand(Id)));
    }
}
