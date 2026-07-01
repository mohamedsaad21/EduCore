using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Payment;
using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public class CreateOrUpdatePaymentIntentCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IFawaterakPaymentService fawaterakPaymentService, IMapper mapper) : IRequestHandler<CreateOrUpdatePaymentIntentCommand, Result<GetCartByCustomerIdResponse>>
{
    public async Task<Result<GetCartByCustomerIdResponse>> Handle(CreateOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        var user = await currentUserService.GetCurrentUserAsync();
        // Check if there's an active cart or not
        var cart = await unitOfWork.Carts.GetTableAsTracking().Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == request.CartId);
        if (cart == null)
            return Errors.CartNotFound;
        // Check if the cart is empty
        if (!cart.CartItems.Any())
            return Errors.EmptyCart;

        var invoice = new EInvoiceRequestModel()
        {
            Currency = "EGP",
            PaymentMethodId = request.PaymentMethodId,
            Customer = new EInvoiceRequestModel.CustomerModel
            {
                // from current logged-in user
                FirstName = user.FullName,
                LastName = user.FullName,
                Email = user.Email,
                CustomerId = user.Id.ToString(),
                Phone = user.PhoneNumber
            },
            CartItems = cart.CartItems.Select(x => new EInvoiceRequestModel.CartItemModel
            {
                Name = x.Course.Title,
                Quantity = 1,
                Price = x.TotalPrice
            }).ToList(),
            PayLoad = new EInvoiceRequestModel.InvoicePayload
            {
                OrderId = "order-id-001"
            },
            RedirectionUrls = new EInvoiceRequestModel.RedirectionUrlsModel
            {
                OnSuccess = "https://domain-of-my-project.com/success",
                OnFailure = "https://domain-of-my-project.com/failure",
                OnPending = "https://domain-of-my-project.com/pending"
            }
        };

        // Call Fawaterak to create the invoice
        var invoiceResult = await fawaterakPaymentService.GeneralPay(invoice);

    }
}