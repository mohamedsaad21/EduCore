using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Basket.Commands.DeleteFromBasket;

public sealed class DeleteFromBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<DeleteFromBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteFromBasketCommand request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        var cart = await unitOfWork.Baskets.GetTableAsTracking().Include(c => c.BasketItems).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);
        if (cart == null)
            return Errors.NotActiveCartFound;

        var cartItem = cart.BasketItems.FirstOrDefault(item => item.CourseId == request.CourseId);
        if (cartItem == null)
            return Errors.CourseNotFoundInCart;

        cart.BasketItems.Remove(cartItem);
        cart.UpdatedAt = DateTime.UtcNow;
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
