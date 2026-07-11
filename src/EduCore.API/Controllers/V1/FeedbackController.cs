using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Application.Features.Feedback.Commands.AddFeedback;
using EduCore.Application.Features.Feedback.Commands.DeleteFeedback;
using EduCore.Application.Features.Feedback.Commands.EditFeedback;
using EduCore.Application.Features.Feedback.Queries.GetCourseFeedbackPaginatedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers.V1;

[Authorize]
public class FeedbackController : AppControllerBase
{
    [HttpGet(Router.FeedbackRouting.Paginated)]
    public async Task<IActionResult> GetCourseFeedbackPaginatedList([FromQuery] GetCourseFeedbackPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpPost(Router.FeedbackRouting.Create)]
    public async Task<IActionResult> AddFeedback([FromBody] AddFeedbackCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpPut(Router.FeedbackRouting.Edit)]
    public async Task<IActionResult> EditFeedback([FromBody] EditFeedbackCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpDelete(Router.FeedbackRouting.Delete)]
    public async Task<IActionResult> DeleteFeedback([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteFeedbackCommand(Id)));
    }
}
