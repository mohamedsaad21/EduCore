using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.ShoppingCart.Commands.ClearCart;

public sealed class ClearCartCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<ClearCartCommand, Result>
{
    public async Task<Result> Handle(ClearCartCommand request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        var cart = await unitOfWork.Carts.GetTableAsTracking().Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);
        if (cart == null)
            return Errors.NotActiveCartFound;

        if (cart.CartItems.Any())
        {
            cart.CartItems.Clear();
            cart.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
        }
        return Result.Success();
    }
}
