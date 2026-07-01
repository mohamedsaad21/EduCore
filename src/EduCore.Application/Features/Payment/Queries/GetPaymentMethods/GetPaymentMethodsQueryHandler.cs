using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Payment.Queries.GetPaymentMethods;

public sealed class GetPaymentMethodsQueryHandler(IFawaterakPaymentService fawaterakPaymentService) : IRequestHandler<GetPaymentMethodsQuery, Result<List<GetPaymentMethodsResponse>>>
{
    public async Task<Result<List<GetPaymentMethodsResponse>>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        var paymentMethods = await fawaterakPaymentService.GetPaymentMethods();
        var response = paymentMethods.Select(x => new GetPaymentMethodsResponse
        {
            Id = x.Id,
            PaymentId = x.PaymentId,
            NameEn = x.NameEn,
            NameAr = x.NameAr,
            Redirect = x.Redirect,
            Logo = x.Logo
        }).ToList();
        return response;
    }
}
