using Domain.Common;
using Domain.Enums;
using Domain.Events;
using Domain.Exceptions;
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
        public string? ProviderReferenceId { get; set; }
        public string? ProviderTransactionId { get; set; }
        public PaymentMethod Method { get; private set; }
        public string? Description { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? CanceledAt { get; private set; }
        public string? FailureReason { get; private set; }
        // Ek bilgi için esnek bir alan
        public Dictionary<string, string>? Metadata { get; private set; }
        public ICollection<RefundRequest> Refunds { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; }

        private readonly List<DomainEvent> domainEvents = [];
        public IReadOnlyCollection<DomainEvent> DomainEvents => domainEvents.AsReadOnly();

        private Payment()
        {
            Metadata = [];
            Refunds = [];
            Transactions = [];
        }

        private Payment(string orderId, Money amount, PaymentProvider provider, PaymentMethod method, string? description, Dictionary<string, string>? metadata)
        {
            OrderId = orderId;
            Amount = amount;
            Provider = provider;
            Method = method;
            Description = description;
            Status = PaymentStatus.Pending;
            Metadata = metadata;
            Refunds = [];
            Transactions = [];
        }

        public static Payment Create(string orderId, Money amount, PaymentProvider provider, PaymentMethod method, string? description, Dictionary<string, string>? metadata)
        {
            if (string.IsNullOrWhiteSpace(orderId)) throw new InvalidPaymentException("Order Id cannot bu empty!");

            if (amount.IsZero() || amount.IsNegative()) throw new InvalidPaymentException("Payment amount must be greater than zero!");

            var payment = new Payment(orderId, amount, provider, method, description, metadata);

            payment.AddDomainEvent(new PaymentCreatedEvent(payment.Id, payment.OrderId, payment.Amount, payment.Provider.ToString()));

            return payment;
        }

        public void MarkAsProcessing(string providerReferenceId)
        {
            if (Status != PaymentStatus.Pending) throw new InvalidPaymentException($"Cannot process payment in {Status} status.");

            Status = PaymentStatus.Processing;
            ProviderReferenceId = providerReferenceId;

            AddTransaction("Processing", "Payment process started.");
            AddDomainEvent(new PaymentProcessingEvent(Id, ProviderReferenceId));
        }

        public void MarkAsCompleted(string providerTransactionId)
        {
            if (Status != PaymentStatus.Processing) throw new InvalidPaymentException($"Cannot complete payment in {Status} status.");

            Status = PaymentStatus.Completed;
            ProviderTransactionId = providerTransactionId;
            CompletedAt = DateTime.UtcNow;

            AddTransaction("Completed", $"Payment completed successfully. Transaction ID: {providerTransactionId}");
            AddDomainEvent(new PaymentCompletedEvent(Id, OrderId, Amount, providerTransactionId));
        }

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public void AddTransaction(string type, string description)
        {
            // Transaction Create aşaması
        }
    }
}
