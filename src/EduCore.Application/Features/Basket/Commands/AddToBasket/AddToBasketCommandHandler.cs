using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Basket.Commands.AddToBasket;

public sealed class AddToBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IEnrollmentService enrollmentService) : IRequestHandler<AddToBasketCommand, Result>
{
    public async Task<Result> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();
        // Check if the course exists or not
        var course = await unitOfWork.Courses.GetTableNoTracking().FirstOrDefaultAsync(c => c.Id == request.CourseId);
        if (course == null)
            return Errors.CourseNotFound;

        // Check if user enrolled in course or not to prevent duplicate order for the same course
        var Enrolled = await enrollmentService.CheckEnrollmentAsync(course, user);
        if (Enrolled) return Errors.AlreadyEnrolledInCourse;

        // Check if there's an active cart or not
        var cart = await unitOfWork.Baskets.GetTableAsTracking()
            .Include(c => c.BasketItems).FirstOrDefaultAsync(c => c.CustomerId == user.Id && !c.IsCheckedOut);
        if (cart == null)
        {
            cart = new Domain.Entities.Basket
            {
                CustomerId = user.Id,
                CreatedAt = DateTime.UtcNow,
            };
            await unitOfWork.Baskets.AddAsync(cart);
            cart.BasketItems = new List<BasketItem>();
        }
        // Check if the course is already exists or not
        var IsExist = cart.BasketItems.Any(item => item.CourseId == course.Id);
        if (IsExist)
            return Errors.CourseAlreadyExistsInCart;

        var basePrice = course.Price;
        var discount = (course.DiscountPercentage / 100) * basePrice;
        var totalPrice = basePrice - discount;
        var cartItem = new BasketItem
        {
            CartId = cart.Id,
            CourseId = course.Id,
            BasePrice = basePrice,
            Discount = discount,
            TotalPrice = totalPrice
        };
        cart.BasketItems.Add(cartItem);
        cart.UpdatedAt = DateTime.UtcNow;

        await unitOfWork.SaveChangesAsync();
        return Result.Success();    
    }
}
