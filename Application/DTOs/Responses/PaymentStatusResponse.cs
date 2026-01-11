namespace Application.DTOs.Responses
{
    public class PaymentStatusResponse
    {
        public Guid PaymentId { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? ProviderTransactionId { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? FailureReason { get; set; }
        public bool CanBeRefunded { get; set; }
        public decimal RefundedAmount { get; set; }
    }
}
