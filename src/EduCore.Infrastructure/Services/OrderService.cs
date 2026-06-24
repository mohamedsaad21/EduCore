using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public OrderService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public IQueryable<Order> GetAllPaginatedListAsync(Guid CustomerId,OrderOrderingEnum OrderBy)
    {
        var orders = _unitOfWork.Orders.GetTableNoTracking().Include(o => o.OrderItems).Where(o => o.CustomerId == CustomerId).AsQueryable();
        orders = OrderBy switch
        {
            OrderOrderingEnum.createdAt => orders.OrderByDescending(o => o.CreatedAt)
        };
        return orders;
    }

    public async Task<Order> GetByIdAsync(Guid? Id)
    {
        var customerId = await _currentUserService.GetCurrentUserId();
        var order = await _unitOfWork.Orders.GetTableNoTracking().Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == Id && o.CustomerId == customerId);
        return order;
    }
}
