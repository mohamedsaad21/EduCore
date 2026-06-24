using EduCore.API.Base;
using EduCore.Application.Features.ShoppingCart.Commands.AddToCart;
using EduCore.Application.Features.ShoppingCart.Commands.ClearCart;
using EduCore.Application.Features.ShoppingCart.Commands.DeleteFromCart;
using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class CartController : AppControllerBase
{
    [HttpGet(Router.CartRouting.List)]
    public async Task<IActionResult> GetCartByCustomerId()
    {
        return ToActionResult(await Mediator.Send(new GetCartByCustomerIdQuery()));
    }

    [HttpPost(Router.CartRouting.Add)]
    public async Task<IActionResult> AddToCart([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new AddToCartCommand(CourseId)));
    }

    [HttpDelete(Router.CartRouting.Delete)]
    public async Task<IActionResult> DeleteFromCart([FromRoute] Guid CourseId)
    {
        return ToActionResult(await Mediator.Send(new DeleteFromCartCommand(CourseId)));
    }

    [HttpDelete(Router.CartRouting.Clear)]
    public async Task<IActionResult> ClearCart()
    {
        return ToActionResult(await Mediator.Send(new ClearCartCommand()));
    }
}
