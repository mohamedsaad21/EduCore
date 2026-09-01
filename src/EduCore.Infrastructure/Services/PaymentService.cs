using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Common.DTOs.Payment;
using EduCore.Domain.Entities;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using EduCore.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace EduCore.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly StripeSettings _stripeSettings;
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;

    public PaymentService(IUnitOfWork unitOfWork, StripeSettings stripeSettings,
        IEnrollmentService enrollmentService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _stripeSettings = stripeSettings;
        _enrollmentService = enrollmentService;
        _mapper = mapper;
    }

    public async Task<PaymentIntentResponseDto> CreateOrUpdatePaymentIntentAsync(Guid basketId)
    {
        StripeConfiguration.ApiKey = _stripeSettings.Secretkey;

        var basket = await _unitOfWork.Baskets.GetTableAsTracking()
            .Include(b => b.BasketItems)
            .Include(b => b.Payments)
            .FirstOrDefaultAsync(x => x.Id == basketId && !x.IsCheckedOut);

        //if (basket is null) throw new BasketNotFoundException(basketId);

        var amount = (long)(basket.BasketItems.Sum(i => i.TotalPrice) * 100);

        // find an existing attempt that hasn't resolved yet
        var pendingPayment = basket.Payments.OrderByDescending(p => p.CreatedAt).FirstOrDefault(p => p.Status == PaymentStatus.Pending);

        var service = new PaymentIntentService();
        Payment payment;

        if (pendingPayment is null) // create new attempt
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = "AED",
                PaymentMethodTypes = ["card"]
            };
            var paymentIntent = await service.CreateAsync(options);

            payment = new Payment
            {
                BasketId = basket.Id,
                PaymentIntentId = paymentIntent.Id,
                ClientSecret = paymentIntent.ClientSecret,
                Amount = amount,
                Status = PaymentStatus.Pending
            };
            await _unitOfWork.Payments.AddAsync(payment);
        }
        else // amount changed since last attempt (basket edited) — update Stripe + row in place
        {
            var options = new PaymentIntentUpdateOptions { Amount = amount };
            await service.UpdateAsync(pendingPayment.PaymentIntentId, options);

            pendingPayment.Amount = amount;
            payment = pendingPayment;
        }

        await _unitOfWork.SaveChangesAsync();

        return new PaymentIntentResponseDto
        {
            ClientSecret = payment.ClientSecret,
            Amount = amount
        };
    }

    public async Task UpdateOrderPaymentStatusAsync(string request, string stripeHeader)
    {
        var endPointSecret = _stripeSettings.WebhookSecret;
        var stripeEvent = EventUtility.ConstructEvent(request, stripeHeader, endPointSecret, throwOnApiVersionMismatch:false);
        var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

        switch (stripeEvent.Type)
        {
            case EventTypes.PaymentIntentPaymentFailed:
                await UpdatePaymentFailedAsync(paymentIntent!.Id);
                break;
            case EventTypes.PaymentIntentSucceeded:
                await UpdatePaymentReceivedAsync(paymentIntent!.Id);
                break;
            default:
                Console.WriteLine($"Unhandled Stripe Event Type {stripeEvent.Type}");
                break;
        }
    }

    private async Task UpdatePaymentReceivedAsync(string paymentIntentId)
    {
        var payment = await _unitOfWork.Payments.GetTableAsTracking().Include(p => p.Basket)
            .ThenInclude(x => x.BasketItems).FirstOrDefaultAsync(p => p.PaymentIntentId == paymentIntentId);

        if (payment is null) return;

        payment.Status = PaymentStatus.Success;

        foreach (var item in payment.Basket.BasketItems)
        {
            await _enrollmentService.CreateEnrollemnt(payment.Basket.CustomerId, item.CourseId);
        }
        payment.Basket.IsCheckedOut = true;
        await _unitOfWork.Baskets.AddAsync(new Basket()
        {
            CustomerId = payment.Basket.CustomerId
        });
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task UpdatePaymentFailedAsync(string paymentIntentId)
    {
        var payment = await _unitOfWork.Payments.GetTableAsTracking().FirstOrDefaultAsync(p => p.PaymentIntentId == paymentIntentId);

        if (payment is null) return;

        payment.Status = PaymentStatus.Failed;
        await _unitOfWork.SaveChangesAsync();
    }
}