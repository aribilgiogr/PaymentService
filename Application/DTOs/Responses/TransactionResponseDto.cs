namespace Application.DTOs.Responses
{
    public class TransactionResponseDto
    {
        public Guid TransactionId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
