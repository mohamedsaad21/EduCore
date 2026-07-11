using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.Payment.Commands.WebHook;

public sealed class WebHookCommandHandler(IPaymentService paymentService, IHttpContextAccessor httpContextAccessor) : IRequestHandler<WebHookCommand, Result>
{
    public async Task<Result> Handle(WebHookCommand request, CancellationToken cancellationToken)
    {
        await paymentService.UpdateOrderPaymentStatusAsync(request.Payload, request.Signature);
        return Result.Success();
    }
}
