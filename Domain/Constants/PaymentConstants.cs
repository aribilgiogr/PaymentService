using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class PaymentConstants
    {
        public const int MaxRefundAttempts = 3;
        public const int MaxPaymentAttempts = 3;
        public const decimal MinPaymentAmount = 0.50m;
        public const decimal MaxPaymentAmount = 999999.99m;

        public static class TransactionTypes
        {
            public const string Created = "Created";
            public const string Completed = "Completed";
            public const string Canceled = "Canceled";
            public const string Processing = "Processing";
            public const string Failed = "Failed";
            public const string RefundRequested = "RefundRequested";
            public const string RefundCompleted = "RefundCompleted";
            public const string RefundFailed = "RefundFailed";
        }

        public static class MetadataKeys
        {
            public const string IpAddress = "IpAddress";
            public const string RetryCount = "RetryCount";
            public const string CallbackUrl = "CallbackUrl";
            public const string WebhookUrl = "WebhookUrl";
            public const string Source = "Source";
        }

        public static class ProviderErrorCodes
        {
            public const string InsufficientFunds = "INSUFFICIENT_FUNDS";
            public const string NetworkError = "NETWORK_ERROR";
            public const string FraudDetected = "FRAUD_DETECTED";
            public const string UnknownError = "UNKNOWN_ERROR";
            public const string Timeout = "TIMEOUT";
            public const string CurrencyNotSupported = "CURRENCY_NOT_SUPPORTED";
            public const string LimitExceeded = "LIMIT_EXCEEDED";
            public const string ProcessingError = "PROCESSING_ERROR";
            public const string TransactionDeclined = "TRANSACTION_DECLINED";
            public const string TransactionError = "TRANSACTION_ERROR";
        }
    }
}
