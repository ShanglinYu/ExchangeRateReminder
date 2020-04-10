using System;

namespace ExchangeRateReminder
{
    class ExchangeRateItem
    {
        public ExchangeRateItem(DateTime updateTime, string currencyFrom, string currencyTo, decimal newPrice, decimal yestdayClose, decimal open, decimal high, decimal low, string desc)
        {
            UpdateTime = updateTime;
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            New = newPrice;
            YestdayClose = yestdayClose;
            Open = open;
            High = high;
            Low = low;
            Desc = desc;
        }

        public DateTime UpdateTime { get; }

        public string CurrencyFrom { get; }

        public string CurrencyTo { get; }

        public decimal New { get; }

        public decimal YestdayClose { get; }

        public decimal Change => New - YestdayClose;

        public decimal Open { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public string Desc { get; }

        public override string ToString()
        {
            return $"{UpdateTime:T} [{CurrencyFrom}{CurrencyTo}]\r\nNew: {New:N4}\r\nChange: {Change:N4}({Change / YestdayClose * 100:N4}%)\r\nPrev Close: {YestdayClose:N4}\r\nOpen: {Open:N4}\r\nHigh: {High:N4}\r\nLow: {Low:N4}\r\nDesc: {Desc}";
        }

        public override bool Equals(object obj)
        {
            var other = obj as ExchangeRateItem;
            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        private bool Equals(ExchangeRateItem other)
        {
            return UpdateTime.Equals(other.UpdateTime) && CurrencyFrom == other.CurrencyFrom && CurrencyTo == other.CurrencyTo && New == other.New && YestdayClose == other.YestdayClose && Open == other.Open && High == other.High && Low == other.Low && Desc == other.Desc;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = UpdateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (CurrencyFrom != null ? CurrencyFrom.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CurrencyTo != null ? CurrencyTo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ New.GetHashCode();
                hashCode = (hashCode * 397) ^ YestdayClose.GetHashCode();
                hashCode = (hashCode * 397) ^ Open.GetHashCode();
                hashCode = (hashCode * 397) ^ High.GetHashCode();
                hashCode = (hashCode * 397) ^ Low.GetHashCode();
                hashCode = (hashCode * 397) ^ (Desc != null ? Desc.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
