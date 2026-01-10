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
        public string OrderId { get; set; } = default!;
        public Money Amount { get; set; } = default!;
        public Money? PaidAmount { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentProvider Provider { get; set; }
        public PaymentMethod Method { get; set; }
        public string? Description { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public string? FailureReason { get; set; }
        // Ek bilgi için esnek bir alan
        public Dictionary<string, string>? Metadata { get; set; }
    }
}
