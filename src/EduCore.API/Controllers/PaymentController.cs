using EduCore.API.Base;
using EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class PaymentController : AppControllerBase
{
    [HttpPost(Router.PaymentRouting.CreatePaymentIntent)]
    public async Task<IActionResult> CreateOrUpdatePaymentIntentAsync([FromRoute] Guid CartId)
    {
        return ToActionResult(await Mediator.Send(new CreateOrUpdatePaymentIntentCommand(CartId)));
    }
}
