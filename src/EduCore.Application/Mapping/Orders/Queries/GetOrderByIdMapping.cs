using EduCore.Application.Features.Orders.Queries.GetOrderById;
using EduCore.Domain.Entities;

namespace EduCore.Core.Mapping.Orders;

public partial class OrderProfile
{
    public void GetOrderByIdMapping()
    {
        CreateMap<Order, GetOrderByIdResponse>();
    }
}
