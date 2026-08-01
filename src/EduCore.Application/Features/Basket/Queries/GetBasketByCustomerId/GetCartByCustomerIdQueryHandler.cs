using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId;

public sealed class GetBasketByCustomerIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper) : IRequestHandler<GetBasketByCustomerIdQuery, Result<GetBasketByCustomerIdResponse>>
{
    public async Task<Result<GetBasketByCustomerIdResponse>> Handle(GetBasketByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        var basket = await unitOfWork.Baskets.GetTableNoTracking().Include(c => c.Customer)
            .Include(c => c.BasketItems).ThenInclude(x => x.Course).FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCheckedOut);

        var basketMapper = mapper.Map<GetBasketByCustomerIdResponse>(basket);
        return basketMapper;
    }
}
