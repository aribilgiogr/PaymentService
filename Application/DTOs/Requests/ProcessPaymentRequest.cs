namespace Application.DTOs.Requests
{
    public class ProcessPaymentRequest
    {
        public string OrderId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Dictionary<string, string>? Metadata { get; set; }
    }
}
