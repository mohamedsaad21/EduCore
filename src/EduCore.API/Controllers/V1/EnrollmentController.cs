using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Application.Features.Enrollments.Queries.GetUserEnrollmentsPaginatedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers.V1;

[Authorize]
public class EnrollmentController : AppControllerBase
{
    [HttpGet(Router.EnrollmentRouting.Paginated)]
    public async Task<IActionResult> GetEnrolledCoursesPaginatedList([FromQuery] GetUserEnrollmentsPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }
}
