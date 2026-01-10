using Domain.Constants;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IPaymentDomainService
    {
        bool CanProcessPayment(Payment payment);

        bool CanRefundPayment(Payment payment, Money refundMoney);
        Money CalculateFee(Money amount, PaymentProvider provider);
        bool IsAmountValid(Money amount);
        bool IsPaymentExpired(Payment payment, TimeSpan timeout);
    }

    public class PaymentDomainService : IPaymentDomainService
    {
        public Money CalculateFee(Money amount, PaymentProvider provider)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            decimal feePerc = GetProviderFeePercentage(provider);

            var percFee = amount.Value * feePerc;
            return new Money(percFee, amount.Currency);
        }

        public bool CanProcessPayment(Payment payment)
        {
            if (payment == null) return false;

            if (payment.Status != PaymentStatus.Pending) return false;

            if (payment.Amount.IsZero()) return false;

            if (payment.Amount.IsNegative()) return false;

            if (!IsAmountValid(payment.Amount)) return false;

            return true;
        }

        public bool CanRefundPayment(Payment payment, Money refundMoney)
        {
            if (payment == null) return false;

            if (payment.Status != PaymentStatus.Completed) return false;

            if (refundMoney.IsZero()) return false;

            if (refundMoney.IsNegative()) return false;

            if (refundMoney.Currency != payment.Amount.Currency) return false;

            return true;
        }

        public bool IsAmountValid(Money amount)
        {
            if (amount == null) return false;
            if (amount.Value < PaymentConstants.MinPaymentAmount) return false;
            if (amount.Value > PaymentConstants.MaxPaymentAmount) return false;
            return true;
        }

        public bool IsPaymentExpired(Payment payment, TimeSpan timeout)
        {
            if (payment == null) return false;

            if (payment.Status == PaymentStatus.Completed || payment.Status == PaymentStatus.Canceled) return false;

            var elapsed = DateTime.UtcNow - payment.CreatedAt;

            return elapsed > timeout;
        }

        #region Private Helper Methods

        private decimal GetProviderFeePercentage(PaymentProvider provider) => provider switch
        {
            PaymentProvider.Mock => 0m,
            PaymentProvider.Stripe => 0.03m,
            PaymentProvider.Iyzico => 0.04m,
            _ => 0.01m
        };

        #endregion
    }
}
