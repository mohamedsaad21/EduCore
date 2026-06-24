using AutoMapper;

namespace EduCore.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserCommandMapping();
            UpdateUserCommandMapping();
            GetUserByIdMapping();
        }
    }
}
