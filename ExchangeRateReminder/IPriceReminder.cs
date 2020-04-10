using System;

namespace ExchangeRateReminder
{
    internal interface IPriceReminder
    {
        event Action<IPriceReminder> ReminderTriggered;

        IExchangeRateRetriever Retriever { get; }

        void Set(IExchangeRateRetriever retriever, decimal targetPrice, string strOperator);

        void Cancel();
    }
}
