namespace Application.DTOs.Responses
{
    public class PaymentMethodResponseDto 
    {
        public string Type { get; set; } = string.Empty;
        public string? CardNumber { get; init; }
        public string? CardHolderName { get; init; }
        public string? BankName { get; init; }
        public string? IbanLastFour { get; init; }
        public string? WalletProvider { get; set; }
    }
}
