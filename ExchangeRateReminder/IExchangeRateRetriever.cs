using System;

namespace ExchangeRateReminder
{
    interface IExchangeRateRetriever
    {
        event Action<ExchangeRateItem> ExchangeRateChanged;

        event Action<ExchangeRateRetrieverStatus> StatusChanged;

        string CurrencyFrom { get; }

        string CurrencyTo { get; }

        string LastError { get; }

        ExchangeRateRetrieverStatus Status { get; }

        ExchangeRateItem ExchangeRate { get; }

        void Start();

        void Stop();
    }
}
