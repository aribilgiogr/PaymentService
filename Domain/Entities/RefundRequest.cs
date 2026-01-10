using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public sealed class RefundRequest : BaseEntity
    {
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = default!;
        public RefundStatus Status { get; set; }
        public string? ProviderRefundId { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? FailureReason { get; set; }
        // Ek bilgi için esnek bir alan
        public Dictionary<string, string>? Metadata { get; set; }
    }
}
