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
        var basket = await unitOfWork.Baskets.GetTableNoTracking().Include(c => c.Customer)
            .Include(c => c.BasketItems).ThenInclude(x => x.Course).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);

        if (basket == null)
            return Errors.EmptyCart;

        var basketMapper = mapper.Map<GetCartByCustomerIdResponse>(basket);
        return basketMapper;
    }
}
