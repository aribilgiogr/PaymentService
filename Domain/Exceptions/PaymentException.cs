using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message) { }
        public PaymentException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InvalidPaymentException : PaymentException
    {
        public InvalidPaymentException(string message) : base(message) { }
        public InvalidPaymentException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InsufficientFundsException : PaymentException
    {
        public Money? RequiredAmount { get; set; }
        public Money? AvailableAmount { get; set; }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }

        public InsufficientFundsException(Money requiredAmount, Money availableAmount) : base($"Insufficient funds. Required: {requiredAmount}, Available: {availableAmount}")
        {
            RequiredAmount = requiredAmount;
            AvailableAmount = availableAmount;
        }
    }

    public class InvalidRefundException : PaymentException
    {
        public InvalidRefundException(string message) : base(message) { }
        public InvalidRefundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class PaymentProviderException : PaymentException
    {
        public string ProviderName { get; }
        public string? ProviderErrorCode { get; }
        public string? ProviderErrorMessage { get; }

        public PaymentProviderException(
            string providerName,
            string message,
            string? providerErrorCode = null,
            string? providerErrorMessage = null)
            : base($"[{providerName}] {message}")
        {
            ProviderName = providerName;
            ProviderErrorCode = providerErrorCode;
            ProviderErrorMessage = providerErrorMessage;
        }

        public PaymentProviderException(
            string providerName,
            string message,
            Exception innerException,
            string? providerErrorCode = null)
            : base($"[{providerName}] {message}", innerException)
        {
            ProviderName = providerName;
            ProviderErrorCode = providerErrorCode;
        }
    }
}
