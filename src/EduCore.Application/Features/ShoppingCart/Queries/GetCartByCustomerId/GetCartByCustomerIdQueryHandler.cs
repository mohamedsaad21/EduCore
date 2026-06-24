using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId.Responses;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.ShoppingCart.Queries.GetCartByCustomerId;

public sealed class GetCartByCustomerIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper) : IRequestHandler<GetCartByCustomerIdQuery, Result<GetCartByCustomerIdResponse>>
{
    public async Task<Result<GetCartByCustomerIdResponse>> Handle(GetCartByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        var cart = await unitOfWork.Carts.GetTableNoTracking().Include(c => c.Customer)
            .Include(c => c.CartItems).ThenInclude(x => x.Course).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);

        if (cart == null)
            return Errors.EmptyCart;

        var cartMapper = mapper.Map<GetCartByCustomerIdResponse>(cart);
        return cartMapper;
    }
}
