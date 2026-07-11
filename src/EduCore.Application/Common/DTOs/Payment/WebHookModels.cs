using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduCore.Application.Common.DTOs.Payment;

public class WebhookPayload
{
    [JsonPropertyName("OrderId")]
    public string? OrderId { get; set; }
}

public class WebHookModel
{
    [JsonPropertyName("invoice_id")]
    [Required]
    public long InvoiceId { get; set; }

    [JsonPropertyName("invoice_key")]
    [Required]
    public string InvoiceKey { get; set; }

    [JsonPropertyName("hashKey")]
    [Required]
    public string HashKey { get; set; }

    [JsonPropertyName("payment_method")]
    [Required]
    public string PaymentMethod { get; set; }

    [JsonPropertyName("invoice_status")]
    [Required]
    public string InvoiceStatus { get; set; }

    [JsonPropertyName("pay_load")]
    public string? PayloadString { get; set; }

    public WebhookPayload? Payload { get; set; }
}

public class CancelTransactionModel
{
    [JsonPropertyName("hashKey")]
    [Required]
    public string HashKey { get; set; }

    [JsonPropertyName("referenceId")]
    [Required]
    public string ReferenceId { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public string Status { get; set; }

    [JsonPropertyName("paymentMethod")]
    [Required]
    public string PaymentMethod { get; set; }

    [JsonPropertyName("pay_load")]
    public object? PayLoad { get; set; }
}

public class FaliledWebHook
{
    [FromForm(Name = "invoice_id")]
    [Required]
    public long InvoiceId { get; set; }

    [FromForm(Name = "invoice_key")]
    [Required]
    public string InvoiceKey { get; set; }

    [FromForm(Name = "errorMessage")]
    [Required]
    public string ErrorMessage { get; set; }
}
