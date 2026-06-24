using Microsoft.AspNetCore.Identity;

namespace EduCore.Domain.Entities.Identity;

public class Role : IdentityRole<Guid>
{
    public Role() : base()
    {
        
    }
    public Role(string roleName) : base(roleName)
    {
        
    }
}
