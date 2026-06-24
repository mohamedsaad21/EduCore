using EduCore.API.Base;
using EduCore.Application.Features.Enrollments.Queries.GetUserEnrollmentsPaginatedList;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

[Authorize]
public class EnrollmentController : AppControllerBase
{
    [HttpGet(Router.EnrollmentRouting.Paginated)]
    public async Task<IActionResult> GetEnrolledCoursesPaginatedList([FromQuery] GetUserEnrollmentsPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }
}
