using EduCore.Domain.Entities;
using EduCore.Domain.Enums;

namespace EduCore.Application.Abstracts;

public interface IOrderService
{
    IQueryable<Order> GetAllPaginatedListAsync(Guid CustomerId, OrderOrderingEnum OrderBy);
    Task<Order> GetByIdAsync(Guid? Id);
}
