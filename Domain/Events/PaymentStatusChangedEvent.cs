namespace Domain.Events
{
    public record PaymentStatusChangedEvent : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public string PreviousStatus { get; init; }
        public string NewStatus { get; init; }

        public PaymentStatusChangedEvent(Guid paymentId, string previousStatus, string newStatus)
        {
            PaymentId = paymentId;
            PreviousStatus = previousStatus;
            NewStatus = newStatus;
        }
    }
}
