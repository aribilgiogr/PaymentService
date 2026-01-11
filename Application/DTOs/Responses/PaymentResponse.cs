namespace Application.DTOs.Responses
{
    public class PaymentResponse
    {
        public Guid PaymentId { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string? ProviderReferenceId { get; set; }
        public string? ProviderTransactionId { get; set; }
        public string? Description { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? FailureReason { get; set; }
        public Dictionary<string, string>? Metadata { get; set; }
        public PaymentMethodResponseDto PaymentMethod { get; set; } = null!;
        public IEnumerable<RefundResponse> Refunds { get; set; } = [];
        public IEnumerable<TransactionResponseDto> Transactions { get; set; } = [];
    }
}
