using EduCore.Application.Common.DTOs.Payment;
using static EduCore.Application.Common.DTOs.Payment.EInvoiceResponseModel;
using static PaymentMethodsResponse;

namespace EduCore.Application.Abstracts;

public interface IFawaterakPaymentService
{
    // Create EInvoice Link
    Task<EInvoiceResponseDataModel?> CreateEInvoiceAsync(EInvoiceRequestModel eInvoice);

    // Payment Integration
    Task<IList<PaymentMethod>?> GetPaymentMethods();
    Task<BasePaymentDataResponse?> GeneralPay(EInvoiceRequestModel invoice);

    // WebHook Verification
    bool VerifyWebhook(WebHookModel webHook);
    bool VerifyCancelTransaction(CancelTransactionModel cancelTransaction);
    bool VerifyApiKeyTransaction(string apiKey);

    // HashKey
    string GenerateHashKeyForIFrame(string domain);
}
