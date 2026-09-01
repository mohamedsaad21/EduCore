using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Core.Features.Certificate.Queries.GetCourseCertificate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers.V1;

[Authorize]
public class CertificateController : AppControllerBase
{
    [HttpGet(Router.CourseCertificateRouting.GetCourseCertificate)]
    public async Task<IActionResult> GetCourseCertificate([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new GetCourseCertificateQuery(CourseId)));
    }
}
