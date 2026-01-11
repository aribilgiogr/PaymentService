using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class PaymentMethodDto
    {
        public string Type { get; set; } = string.Empty;
        public CardDetailsDto? Card { get; set; }
        public BankTransferDetailsDto? BankTransfer { get; set; }
        public DigitalWalletDetailsDto? DigitalWallet { get; set; }
    }

    public class CardDetailsDto
    {
        public string Number { get; set; } = string.Empty;
        public string HolderName { get; set; } = string.Empty;
        public string ExpiryMonth { get; set; } = string.Empty;
        public string ExpiryYear { get; set; } = string.Empty;
        public string? Cvv { get; set; }
    }
    public class BankTransferDetailsDto
    {
        public string BankName { get; set; } = string.Empty;
        public string Iban { get; set; } = string.Empty;
        public string HolderName { get; set; } = string.Empty;
    }
    public class DigitalWalletDetailsDto
    {
        public string Provider { get; set; } = string.Empty;
        public string? WalletId { get; set; }
        public string? Token { get; set; }
    }

}
