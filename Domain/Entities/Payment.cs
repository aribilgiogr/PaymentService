using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Payment : BaseEntity
    {
        public string OrderId { get; private set; }
        public Money Amount { get; private set; }
        public Money? PaidAmount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public PaymentProvider Provider { get; private set; }
        public PaymentMethod Method { get; private set; }
        public string? Description { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? CanceledAt { get; private set; }
        public string? FailureReason { get; private set; }
        // Ek bilgi için esnek bir alan
        public Dictionary<string, string>? Metadata { get; private set; }
        public ICollection<RefundRequest> Refunds { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; }

        private Payment()
        {
            Metadata = [];
            Refunds = [];
            Transactions = [];
        }

        public Payment(string orderId, Money amount, PaymentProvider provider, PaymentMethod method, Dictionary<string, string>? metadata)
        {
            OrderId = orderId;
            Amount = amount;
            Provider = provider;
            Method = method;
            Metadata = metadata;
            Refunds = [];
            Transactions = [];
        }

    }
}
