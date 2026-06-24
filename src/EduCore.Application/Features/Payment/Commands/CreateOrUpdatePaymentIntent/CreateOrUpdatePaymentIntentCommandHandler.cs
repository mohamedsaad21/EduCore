using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses;
using MediatR;

namespace EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public class CreateOrUpdatePaymentIntentCommandHandler(IPaymentService paymentService, IMapper mapper) : IRequestHandler<CreateOrUpdatePaymentIntentCommand, Result<GetCartByCustomerIdResponse>>
{
    public async Task<Result<GetCartByCustomerIdResponse>> Handle(CreateOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
    {
        var cart = await paymentService.CreateOrUpdatePaymentIntentAsync(request.CartId);
        var cartMapper = mapper.Map<GetCartByCustomerIdResponse>(cart);
        return cartMapper;
    }
}