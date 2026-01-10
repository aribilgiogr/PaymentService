using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICurrencyConversionService
    {
        Task<Money> ConvertAsync(Money money, Currency targetCurrency, CancellationToken cancellationToken = default);
        Task<decimal> GetExchangeRateAsync(Currency from, Currency to, CancellationToken cancellationToken = default);
    }

    public class CurrencyConversionService : ICurrencyConversionService
    {
        public async Task<Money> ConvertAsync(Money money, Currency targetCurrency, CancellationToken cancellationToken = default)
        {
            decimal rate = await GetExchangeRateAsync(money.Currency, targetCurrency);
            return money.Multiply(rate);
        }

        public Task<decimal> GetExchangeRateAsync(Currency from, Currency to, CancellationToken cancellationToken = default)
        {
            // İlgili kaynaklara bakılarak kullanılacaktır.
            throw new NotImplementedException();
        }
    }
}
