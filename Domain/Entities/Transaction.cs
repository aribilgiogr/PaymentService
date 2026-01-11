using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public sealed class Transaction : BaseEntity
    {
        public Guid PaymentId { get; private set; }
        public Payment Payment { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Type { get; private set; } = default!;
        public PaymentStatus StatusAtTime { get; private set; }


        private Transaction() { }

        private Transaction(Guid paymentId, string type, string description, PaymentStatus paymentStatusAtTime)
        {
            PaymentId = paymentId;
            Type = type;
            Description = description;
            StatusAtTime = paymentStatusAtTime;
        }

        public static Transaction Create(Guid paymentId, string type, string description, PaymentStatus paymentStatusAtTime)
        {
            if (paymentId == Guid.Empty) throw new ArgumentException("Payment ID cannot be empty!", nameof(paymentId));
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException("Transaction type cannot be empty!", nameof(type));

            return new Transaction(paymentId, type, description, paymentStatusAtTime);
        }
    }
}
