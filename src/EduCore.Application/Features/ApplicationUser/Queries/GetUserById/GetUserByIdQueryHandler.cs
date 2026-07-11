using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.ApplicationUser.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler(UserManager<User> userManager, IMapper mapper) : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdResponse>>
{
    public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
        if (user == null) return Errors.UserNotFound;
        var userMapper = mapper.Map<GetUserByIdResponse>(user);
        return userMapper;
    }
}
