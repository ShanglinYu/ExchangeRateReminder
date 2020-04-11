using System;

namespace ExchangeRateReminder
{
    internal interface IPriceReminder
    {
        event Action<IPriceReminder, bool> ReminderSet; 

        event Action<IPriceReminder> ReminderTriggered;

        IExchangeRateRetriever Retriever { get; }

        bool IsSet { get; }

        void Set(IExchangeRateRetriever retriever, decimal targetPrice, string strOperator);

        void Cancel();
    }
}
