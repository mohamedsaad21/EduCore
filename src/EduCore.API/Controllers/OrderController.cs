using EduCore.API.Base;
using EduCore.Application.Features.Orders.Commands.CreateOrder;
using EduCore.Application.Features.Orders.Queries.GetOrderById;
using EduCore.Core.Features.Orders.Queries.Models;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class OrderController : AppControllerBase
{
    [HttpGet(Router.OrderRouting.Paginated)]
    public async Task<IActionResult> GetAllOrdersPaginatedList([FromQuery] GetOrdersPaginatedListQuery query)
    {
        return ToActionResult(await Mediator.Send(query));
    }

    [HttpGet(Router.OrderRouting.GetById)]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid Id)
    {
        return ToActionResult(await Mediator.Send(new GetOrderByIdQuery(Id)));
    }

    [HttpPost(Router.OrderRouting.Create)]
    public async Task<IActionResult> CreateOrder([FromRoute] Guid CartId)
    {
        return ToActionResult(await Mediator.Send(new CreateOrderCommand(CartId)));
    }
}
