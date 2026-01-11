using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.ValueObjects
{
    public record PaymentMethod
    {
        public PaymentMethodType Type { get; init; }
        public string? CardNumber { get; init; } // Masked: **** **** **** 1234
        public string? CardHolderName { get; init; }
        public string? CardExprity { get; init; }
        public string? BankName { get; init; }
        public string? IbanLastFour { get; init; }
        public Dictionary<string, string> AdditionalData { get; init; }

        private PaymentMethod()
        {
            AdditionalData = [];
        }

        public static PaymentMethod CreateCreditCard(string number, string holderName, string exprity)
        {
            if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Card number is required!", nameof(number));

            return new PaymentMethod()
            {
                Type = PaymentMethodType.CreditCard,
                CardNumber = MaskCardNumber(number),
                CardHolderName = holderName,
                CardExprity = exprity,
                AdditionalData = []
            };
        }

        public static PaymentMethod CreateDebitCard(string number, string holderName, string exprity)
        {
            if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Card number is required!", nameof(number));

            return new PaymentMethod()
            {
                Type = PaymentMethodType.DebitCard,
                CardNumber = MaskCardNumber(number),
                CardHolderName = holderName,
                CardExprity = exprity,
                AdditionalData = []
            };
        }

        public static PaymentMethod CreateBankTransfer(string bankName, string iban)
        {
            if (string.IsNullOrWhiteSpace(iban)) throw new ArgumentException("Iban is required!", nameof(iban));

            return new PaymentMethod
            {
                Type = PaymentMethodType.BankTransfer,
                BankName = bankName,
                IbanLastFour = iban.Length > 4 ? iban.Substring(iban.Length - 4) : iban,
                AdditionalData = []
            };
        }

        public static PaymentMethod CreateDigitalWallet(string walletProvider)
        {
            return new PaymentMethod
            {
                Type = PaymentMethodType.DigitalWallet,
                AdditionalData = new Dictionary<string, string>
                {
                    {"Provider",walletProvider }
                }
            };
        }

        public static PaymentMethod CreateCash()
        {
            return new PaymentMethod
            {
                Type = PaymentMethodType.Cash,
                AdditionalData = []
            };
        }

        #region Helpers

        private static string MaskCardNumber(string number)
        {
            var cleaned = number.Replace(" ", "").Replace("-", "");
            if (cleaned.Length < 4) return "****";

            var lastFour = cleaned[^4..];
            return $"**** **** **** {lastFour}";
        }

        #endregion
    }
}