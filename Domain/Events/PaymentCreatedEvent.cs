using Domain.ValueObjects;

namespace Domain.Events
{
    // Ödeme oluşturuldu.
    public record PaymentCreatedEvent : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public string OrderId { get; init; }
        public Money Amount { get; init; }
        public string Provider { get; init; }

        public PaymentCreatedEvent(Guid paymentId, string orderId, Money amount, string provider)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            Provider = provider;
        }
    }

    // Ödeme işleniyor.
    public record PaymentProcessingEvent : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public string ProviderReferenceId { get; init; }

        public PaymentProcessingEvent(Guid paymentId, string providerReferenceId)
        {
            PaymentId = paymentId;
            ProviderReferenceId = providerReferenceId;
        }
    }

    // Ödeme tamamlandı.
    public record PaymentCompletedEvent : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public string OrderId { get; init; }
        public Money Amount { get; init; }
        public string ProviderTransactionId { get; init; }

        public PaymentCompletedEvent(Guid paymentId, string orderId, Money amount, string providerTransactionId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            ProviderTransactionId = providerTransactionId;
        }
    }

    // Ödeme başarısız.
    public record PaymentFailedEvent : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public string OrderId { get; init; }
        public string Reason { get; init; }
        public string? ErrorCode { get; init; }

        public PaymentFailedEvent(Guid paymentId, string orderId, string reason, string? errorCode = null)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Reason = reason;
            ErrorCode = errorCode;
        }
    }

    // Ödeme iptal edildi.
    public record PaymentCancelledEvent : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public string OrderId { get; init; }
        public string CancellationReason { get; init; }

        public PaymentCancelledEvent(Guid paymentId, string orderId, string cancellationReason)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            CancellationReason = cancellationReason;
        }
    }

}
