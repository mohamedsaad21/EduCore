using EduCore.API.Contracts.Routing;
using EduCore.API.Controllers.Common;
using EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;
using EduCore.Application.Features.Payment.Commands.WebHook;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers.V1;

public class PaymentController : AppControllerBase
{
    [HttpPost(Router.PaymentRouting.CreatePaymentIntent)]
    public async Task<IActionResult> CreateOrUpdatePaymentIntentAsync([FromRoute] CreateOrUpdatePaymentIntentCommand command)
    {
        return ToActionResult(await Mediator.Send(command));
    }

    [HttpPost(Router.PaymentRouting.WebHook)]
    public async Task<IActionResult> WebHook()
    {
        string payload;
        using (var reader = new StreamReader(HttpContext.Request.Body))
            payload = await reader.ReadToEndAsync();

        var signature = Request.Headers["Stripe-Signature"];
        return ToActionResult(await Mediator.Send(new WebHookCommand(payload, signature)));
    }
}
