using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Application.Features.Enrollments.Queries.GetUserEnrollmentsPaginatedList;
using EduCore.Core.Features.Enrollments.Queries.CheckUserEnrollment;
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
    
    [HttpGet(Router.EnrollmentRouting.Check)]
    public async Task<IActionResult> CheckUserEnrollment([FromRoute] CheckUserEnrollmentQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }
}
