using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Basket.Commands.ClearBasket;

public sealed class ClearBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<ClearBasketCommand, Result>
{
    public async Task<Result> Handle(ClearBasketCommand request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        var cart = await unitOfWork.Baskets.GetTableAsTracking().Include(c => c.BasketItems).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);
        if (cart == null)
            return Errors.NotActiveCartFound;

        if (cart.BasketItems.Any())
        {
            cart.BasketItems.Clear();
            cart.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
        }
        return Result.Success();
    }
}
