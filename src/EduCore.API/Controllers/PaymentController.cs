using EduCore.API.Base;
using EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;
using EduCore.Application.Features.Payment.Queries.GetPaymentMethods;
using EduCore.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers;

public class PaymentController : AppControllerBase
{
    [HttpGet(Router.PaymentRouting.GetPaymentMethods)]
    public async Task<IActionResult> GetPaymentMethods()
    {
        return ToActionResult(await Mediator.Send(new GetPaymentMethodsQuery()));
    }

    [HttpPost(Router.PaymentRouting.CreatePaymentIntent)]
    public async Task<IActionResult> CreateOrUpdatePaymentIntentAsync([FromBody] CreateOrUpdatePaymentIntentCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }
}
