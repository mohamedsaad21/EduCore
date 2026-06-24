using EduCore.API.Base;
using Microsoft.AspNetCore.Mvc;
using EduCore.Core.Filters;
using EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;
using EduCore.Core.Features.Courses.Queries.GetCoursesByCategoryIdPaginatedList;
using EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;
using EduCore.Core.Features.Courses.Commands.AddCourse;
using EduCore.Application.Features.Courses.Commands.EditCourse;
using EduCore.Domain.AppMetaData;
using EduCore.Application.Features.Courses.Queries.GetCourseById;
using EduCore.Application.Features.Courses.Commands.DeleteCourse;

namespace EduCore.API.Controllers;

public class CourseController : AppControllerBase
{
    [HttpGet(Router.CourseRouting.Paginated)]
    public async Task<IActionResult> GetCoursesPaginatedList([FromQuery] GetCoursePaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.CourseRouting.ByCategoryIdPaginated)]
    public async Task<IActionResult> GetCoursesByCategoryIdPaginatedList([FromQuery] GetCoursesByCategoryIdPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.CourseRouting.ByInstructorIdPaginated)]
    public async Task<IActionResult> GetCoursesByInstructorIdPaginatedList([FromQuery] GetCoursesByInstructorIdPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.CourseRouting.GetById)]
    public async Task<IActionResult> GetCourseById([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetCourseByIdQuery(Id)));
    }

    [HttpPost(Router.CourseRouting.Create)]
    [ServiceFilter(typeof(AuthFilter))]
    public async Task<IActionResult> CreateCourse([FromForm] AddCourseCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpPut(Router.CourseRouting.Edit)]
    [ServiceFilter(typeof(AuthFilter))]
    public async Task<IActionResult> EditCourse([FromForm] EditCourseCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpDelete(Router.CourseRouting.Delete)]
    [ServiceFilter(typeof(AuthFilter))]
    public async Task<IActionResult> DeleteCourse([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new DeleteCourseCommand(Id)));
    }
}
