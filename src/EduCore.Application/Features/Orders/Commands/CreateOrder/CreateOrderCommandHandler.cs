using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customerId = await currentUserService.GetCurrentUserId();
        // Check if there's an active cart or not
        var cart = await unitOfWork.Carts.GetTableAsTracking().Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == request.CartId);
        if (cart == null)
            return Errors.CartNotFound;
        // Check if the cart is empty
        if (!cart.CartItems.Any())
            return Errors.EmptyCart;

        var order = new Order { CustomerId = customerId, CreatedAt = DateTime.UtcNow };
        // Mapping cart items to order items
        order.OrderItems = cart.CartItems.Select(e => new OrderItem
        {
            CourseId = e.CourseId,
            BasePrice = e.BasePrice,
            Discount = e.Discount,
            TotalPrice = e.TotalPrice,
            OrderId = order.Id
        }).ToList();
        order.TotalBaseAmount = order.OrderItems.Sum(item => item.BasePrice);
        order.TotalDiscountAmount = order.OrderItems.Sum(item => item.Discount);
        order.TotalAmount = order.OrderItems.Sum(item => item.TotalPrice);

        await unitOfWork.Orders.AddAsync(order);
        // Get Cart Checkout True
        cart.IsCheckedOut = true;

        // Enrolled User in All Courses in order
        var enrollmentedCourses = order.OrderItems.Select(item => new Enrollment
        {
            UserId = customerId,
            CourseId = item.CourseId,
            OrderId = item.OrderId,
            EnrolledAt = DateTime.UtcNow,
        }).ToList();

        //await unitOfWork.Enrollments.AddRangeAsync(enrollmentedCourses);
        await unitOfWork.SaveChangesAsync();
        return order.Id;
    }
}
