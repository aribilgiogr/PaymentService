using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record RefundRequestedEvent : DomainEvent
    {
        public Guid RefundId { get; init; }
        public Guid PaymentId { get; set; }
        public Money Amount { get; set; }
        public string Reason { get; set; }

        public RefundRequestedEvent(Guid refundId, Guid paymentId, Money amount, string reason)
        {
            RefundId = refundId;
            PaymentId = paymentId;
            Amount = amount;
            Reason = reason;
        }
    }

    public record RefundProcessingEvent : DomainEvent
    {
        public Guid RefundId { get; init; }
        public Guid PaymentId { get; set; }
        public string ProviderRefundId { get; set; }

        public RefundProcessingEvent(Guid refundId, Guid paymentId, string providerRefundId)
        {
            RefundId = refundId;
            PaymentId = paymentId;
            ProviderRefundId = providerRefundId;
        }
    }

    public record RefundCompletedEvent : DomainEvent
    {
        public Guid RefundId { get; init; }
        public Guid PaymentId { get; set; }
        public Money Amount { get; set; }

        public RefundCompletedEvent(Guid refundId, Guid paymentId, Money amount)
        {
            RefundId = refundId;
            PaymentId = paymentId;
            Amount = amount;
        }
    }

    public record RefundFailedEvent : DomainEvent
    {
        public Guid RefundId { get; init; }
        public Guid PaymentId { get; set; }
        public string Reason { get; set; }
        public string? ErrorCode { get; set; }

        public RefundFailedEvent(Guid refundId, Guid paymentId, string reason, string? errorCode = null)
        {
            RefundId = refundId;
            PaymentId = paymentId;
            Reason = reason;
            ErrorCode = errorCode;
        }
    }

    public record RefundCancelledEvent : DomainEvent
    {
        public Guid RefundId { get; init; }
        public Guid PaymentId { get; set; }

        public RefundCancelledEvent(Guid refundId, Guid paymentId)
        {
            RefundId = refundId;
            PaymentId = paymentId;
        }
    }
}
