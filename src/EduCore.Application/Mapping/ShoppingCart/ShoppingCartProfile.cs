using AutoMapper;

namespace EduCore.Core.Mapping.ShoppingCart
{
    public partial class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            GetCartByCustomerIdMapping();
        }
    }
}
