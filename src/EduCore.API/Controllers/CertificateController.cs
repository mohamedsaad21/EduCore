using EduCore.API.Base;
using EduCore.Core.Features.Certificate.Queries.GetCourseCertificate;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

[Authorize]
public class CertificateController : AppControllerBase
{
    [HttpGet(Router.CourseCertificateRouting.GetCourseCertificate)]
    public async Task<IActionResult> GetCourseCertificate([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new GetCourseCertificateQuery(CourseId)));
    }
}
