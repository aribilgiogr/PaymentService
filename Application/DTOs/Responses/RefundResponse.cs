namespace Application.DTOs.Responses
{
    public class RefundResponse
    {
        public Guid RefundId { get; set; }
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string? ProviderRefundId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public string? FailureReason { get; set; }
    }
}
