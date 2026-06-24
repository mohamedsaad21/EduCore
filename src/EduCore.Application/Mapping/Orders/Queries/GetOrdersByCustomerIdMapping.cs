using EduCore.Application.Common.DTOs.Order;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Orders;

public partial class OrderProfile
{
    public void GetOrdersByCustomerIdMapping()
    {
        CreateMap<OrderItem, GetOrderItemResponse>();
    }
}
