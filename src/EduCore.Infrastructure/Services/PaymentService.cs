using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace EduCore.Service.Implementation;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly ICurrentUserService _currentUserService;

    public PaymentService(IConfiguration configuration, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Cart> CreateOrUpdatePaymentIntentAsync(Guid CartId)
    {
        StripeConfiguration.ApiKey = _configuration["Stripe:Secretkey"];
        var customerId = _currentUserService.GetCurrentUserId();
        // Check if there's an active cart or not
        var cart = await _unitOfWork.Carts.GetTableAsTracking().Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == CartId);
        if (cart == null)
        {
            throw new KeyNotFoundException("cart not found!");
        }

        var cartAmount = (long)cart.CartItems.Sum(i => i.TotalPrice) * 100;

        var PaymentServices = new PaymentIntentService();

        if (cart.PaymentIntentId == null)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = cartAmount,
                Currency = "USD",
                PaymentMethodTypes = ["card"],
            };
            var intent = await PaymentServices.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        else
        {
            var options = new PaymentIntentUpdateOptions
            {
                Amount = cartAmount,
            };
            await PaymentServices.UpdateAsync(cart.PaymentIntentId, options);
        }
        await _unitOfWork.SaveChangesAsync();
        return cart;
    }
}
