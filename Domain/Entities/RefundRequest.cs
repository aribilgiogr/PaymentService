using Domain.Common;
using Domain.Enums;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class RefundRequest : BaseEntity
    {
        public Guid PaymentId { get; private set; }
        public Payment Payment { get; private set; } = default!;
        public Money Amount { get; private set; } = default!;
        public string Reason { get; private set; } = default!;
        public RefundStatus Status { get; private set; }
        public string? ProviderRefundId { get; private set; }
        public DateTime? ProcessedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public string? FailureReason { get; private set; }

        // EF core parametresiz yapıcı ile çalışır.
        private RefundRequest() { }

        private RefundRequest(Guid paymentId, Money amount, string reason)
        {
            PaymentId = paymentId;
            Amount = amount;
            Reason = reason;
            Status = RefundStatus.Pending;
        }

        public static RefundRequest Create(Guid paymentId, Money amount, string reason)
        {
            if (paymentId == Guid.Empty) throw new ArgumentException("Payment ID cannot be empty!", nameof(paymentId));
            if (string.IsNullOrWhiteSpace(reason)) throw new ArgumentException("Refund reason be empty!", nameof(reason));
            if (amount.IsZero() || amount.IsNegative()) throw new InvalidPaymentException("Refund amount must be greater than zero!");

            return new RefundRequest(paymentId, amount, reason);
        }

        public void MarkAsProcessing(string providerRefundId)
        {
            if (Status != RefundStatus.Pending) throw new InvalidPaymentException($"Cannot process refund in {Status} status.");

            Status = RefundStatus.Processing;
            ProviderRefundId = providerRefundId;
            ProcessedAt = DateTime.UtcNow;
        }

        public void MarkAsCompleted()
        {
            if (Status != RefundStatus.Processing) throw new InvalidPaymentException($"Cannot complete refund in {Status} status.");

            Status = RefundStatus.Completed;
            CompletedAt = DateTime.UtcNow;
        }

        public void MarkAsFailed(string reason)
        {
            if (Status == RefundStatus.Completed) throw new InvalidPaymentException($"Cannot fail a completed refund.");

            Status = RefundStatus.Failed;
            FailureReason = reason;
        }

        public void MarkAsCancelled()
        {
            if (Status == RefundStatus.Completed) throw new InvalidPaymentException($"Cannot cancel a completed refund.");
            if (Status == RefundStatus.Processing) throw new InvalidPaymentException($"Cannot cancel a processing refund.");

            Status = RefundStatus.Canceled;
        }
    }
}
