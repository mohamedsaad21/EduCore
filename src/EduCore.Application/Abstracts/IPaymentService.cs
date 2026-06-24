using EduCore.Domain.Entities;

namespace EduCore.Application.Abstracts;

public interface IPaymentService
{
    Task<Cart> CreateOrUpdatePaymentIntentAsync(Guid CartId);
}
