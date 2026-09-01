using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Application.Features.CourseProgress.Commands.ChangeContentCompletionStatus;
using EduCore.Application.Features.CourseProgress.Queries.GetCourseProgress;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers.V1;

public class CourseProgressController : AppControllerBase
{
    [HttpPost(Router.CourseProgressRouting.ChangeContentStatus)]
    public async Task<IActionResult> ChangeContentCompletionStatus([FromBody] ChangeContentCompletionStatusCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpGet(Router.CourseProgressRouting.GetCourseProgress)]
    public async Task<IActionResult> GetCourseProgress([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new GetCourseProgressQuery(CourseId)));
    }
}
