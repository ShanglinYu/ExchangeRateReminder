namespace ExchangeRateReminder
{
    internal class Factory
    {
        public static IExchangeRateRetriever NewExchangeRateRetriever(string currencyFrom, string currencyTo)
        {
            return new ExchangeRateRetrieverSina(currencyFrom, currencyTo);
        }

        public static IPriceReminder NewPriceReminder()
        {
            return new NewPriceReminder();
        }
    }
}
