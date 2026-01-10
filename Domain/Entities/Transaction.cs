using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public sealed class Transaction : BaseEntity
    {
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = default!;
        public string? Description { get; set; }
        public string? Type { get; set; }
        public PaymentStatus StatusAtTime { get; set; }
        // Ek bilgi için esnek bir alan
        public Dictionary<string, string>? Metadata { get; set; }
    }
}
