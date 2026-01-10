using Domain.Enums;

namespace Domain.ValueObjects
{
    public record Money
    {
        // init: sadece nesne oluşturulurken atanabilir, sonrasında değiştirilemez.
        // ValueObject: Kendimize ait bir şablonu referans veri tipleri gibi kullanabilmek için yazılan yapılar.
        public decimal Value { get; init; }
        public Currency Currency { get; init; }

        public Money(decimal value, Currency currency)
        {
            if (value < 0)
                throw new ArgumentException("Money value cannot be negative.", nameof(value));

            Value = Math.Round(value, 2);
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (other.Currency != Currency)
                throw new InvalidOperationException("Cannot add Money with different currencies.");
            return new Money(Value + other.Value, Currency);
        }

        public Money Subtract(Money other)
        {
            if (other.Currency != Currency)
                throw new InvalidOperationException("Cannot subtract Money with different currencies.");

            var result = Value - other.Value;

            if (result < 0)
                throw new InvalidOperationException("Resulting Money value cannot be negative.");
            return new Money(result, Currency);
        }

        public Money Multiply(decimal multiplier)
        {
            if (multiplier < 0)
                throw new ArgumentException("Factor cannot be negative.", nameof(multiplier));
            return new Money(Value * multiplier, Currency);
        }

        public Money Divide(decimal divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("Divisor must be greater than zero.", nameof(divisor));
            return new Money(Value / divisor, Currency);
        }

        public bool IsZero() => Value == 0;
        public bool IsPositive() => Value > 0;
        public bool IsNegative() => Value < 0;
        public override string ToString() => $"{Value:N2} {Currency}";
    }
}
