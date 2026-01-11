namespace Application.DTOs.Requests
{
    public class RefundPaymentRequest
    {
        public Guid PaymetId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
