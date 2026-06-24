using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.ShoppingCart.Commands.DeleteFromCart;

public sealed class DeleteFromCartCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<DeleteFromCartCommand, Result>
{
    public async Task<Result> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        var cart = await unitOfWork.Carts.GetTableAsTracking().Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);
        if (cart == null)
            return Errors.NotActiveCartFound;

        var cartItem = cart.CartItems.FirstOrDefault(item => item.CourseId == request.CourseId);
        if (cartItem == null)
            return Errors.CourseNotFoundInCart;

        cart.CartItems.Remove(cartItem);
        cart.UpdatedAt = DateTime.UtcNow;
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
