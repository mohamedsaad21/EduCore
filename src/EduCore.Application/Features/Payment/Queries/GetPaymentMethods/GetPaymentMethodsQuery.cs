using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Payment.Queries.GetPaymentMethods;

public sealed record GetPaymentMethodsQuery() : IRequest<Result<List<GetPaymentMethodsResponse>>>;
