using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record TransactionCreatedEvent : DomainEvent
    {
        public Guid TransactionId { get; init; }
        public Guid PaymentId { get; init; }
        public string Type { get; init; }
        public string Description { get; init; }

        public TransactionCreatedEvent(Guid transactionId, Guid paymentId, string type, string description)
        {
            TransactionId = transactionId;
            PaymentId = paymentId;
            Type = type;
            Description = description;
        }
    }
}
