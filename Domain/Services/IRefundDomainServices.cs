using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Services
{
    public interface IRefundDomainServices
    {
        bool CanCreateRefund(Payment payment, Money refundAmount);
        bool CanFullRefund(Payment payment);
        bool CanPartialRefund(Payment payment);
        Money GetMaxRefundableAmount(Payment payment);
    }

    public class RefundDomainService : IRefundDomainServices
    {
        public bool CanCreateRefund(Payment payment, Money refundAmount)
        {
            if (payment == null || refundAmount == null) return false;

            if (payment.Status != PaymentStatus.Completed) return false;

            if (refundAmount.IsZero()) return false;

            if (refundAmount.IsNegative()) return false;

            if (refundAmount.Value > GetMaxRefundableAmount(payment).Value) return false;

            if (refundAmount.Currency != payment.Amount.Currency) return false;

            return true;
        }

        public bool CanFullRefund(Payment payment)
        {
            if (payment == null) return false;
            if (payment.Status != PaymentStatus.Completed) return false;

            return true;
        }

        public bool CanPartialRefund(Payment payment)
        {
            if (payment == null) return false;
            if (payment.Status != PaymentStatus.Completed) return false;

            return payment.Amount.Value > GetMaxRefundableAmount(payment).Value;
        }

        public Money GetMaxRefundableAmount(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
