using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.ShoppingCart.Commands.AddToCart;

public sealed class AddToCartCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IEnrollmentService enrollmentService) : IRequestHandler<AddToCartCommand, Result>
{
    public async Task<Result> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();
        // Check if the course exists or not
        var course = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(c => c.Id == request.CourseId);
        if (course == null)
            return Errors.CourseNotFound;

        // Check if user enrolled in course or not to prevent duplicate order for the same course
        var Enrolled = await enrollmentService.CheckEnrollmentAsync(course, user);
        if (Enrolled) return Errors.NotEnrolledInCourse;

        // Check if there's an active cart or not
        var cart = await unitOfWork.Carts.GetTableAsTracking()
            .Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CustomerId == user.Id && !c.IsCheckedOut);
        if (cart == null)
        {
            cart = new Cart
            {
                CustomerId = user.Id,
                CreatedAt = DateTime.UtcNow,
            };
            await unitOfWork.Carts.AddAsync(cart);
            cart.CartItems = new List<CartItem>();
        }
        // Check if the course is already exists or not
        var IsExist = cart.CartItems.Any(item => item.CourseId == course.Id);
        if (IsExist)
            return Errors.CourseAlreadyExistsInCart;

        var basePrice = course.Price;
        var discount = (course.DiscountPercentage / 100) * basePrice;
        var totalPrice = basePrice - discount;
        var cartItem = new CartItem
        {
            CartId = cart.Id,
            CourseId = course.Id,
            BasePrice = basePrice,
            Discount = discount,
            TotalPrice = totalPrice
        };
        cart.CartItems.Add(cartItem);
        cart.UpdatedAt = DateTime.UtcNow;

        await unitOfWork.SaveChangesAsync();
        return Result.Success();
        }
}
