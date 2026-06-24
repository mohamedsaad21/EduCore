using AutoMapper;

namespace EduCore.Core.Mapping.Orders
{
    public partial class OrderProfile : Profile
    {
        public OrderProfile()
        {
            GetOrdersByCustomerIdMapping();
            GetOrderByIdMapping();
        }
    }
}
