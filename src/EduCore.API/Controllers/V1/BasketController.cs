using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Application.Features.Basket.Commands.AddToBasket;
using EduCore.Application.Features.Basket.Commands.ClearBasket;
using EduCore.Application.Features.Basket.Commands.DeleteFromBasket;
using EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers.V1;

public class BasketController : AppControllerBase
{
    [HttpGet(Router.BasketRouting.List)]
    public async Task<IActionResult> GetBasketByCustomerId()
    {
        return ToActionResult(await Mediator.Send(new GetBasketByCustomerIdQuery()));
    }

    [HttpPost(Router.BasketRouting.Add)]
    public async Task<IActionResult> AddToBasket([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new AddToBasketCommand(CourseId)));
    }

    [HttpDelete(Router.BasketRouting.Delete)]
    public async Task<IActionResult> DeleteFromBasket([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new DeleteFromBasketCommand(CourseId)));
    }

    [HttpDelete(Router.BasketRouting.Clear)]
    public async Task<IActionResult> ClearBasket()
    {
        return ToActionResult(await Mediator.Send(new ClearBasketCommand()));
    }
}
