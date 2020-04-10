using System;
using System.Threading;

namespace ExchangeRateReminder
{
    sealed class ExchangeRateRetrieverSina : IExchangeRateRetriever
    {
        private const int MaxRetryTimes = 12;

        private ExchangeRateRetrieverStatus _status;
        private ExchangeRateItem _exchangeRate;
        private Thread _retrievingThread;
        private int _retryTimes;

        public event Action<ExchangeRateItem> ExchangeRateChanged;
        public event Action<ExchangeRateRetrieverStatus> StatusChanged;

        public ExchangeRateRetrieverSina(string currencyFrom, string currencyTo)
        {
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Status = ExchangeRateRetrieverStatus.Stopped;
            _retrievingThread = new Thread(StartRetrieving)
            {
                IsBackground = true,
                Name = Name
            };
        }

        public string Name => $"{CurrencyFrom}-{CurrencyTo}";

        public string CurrencyFrom
        {
            get;
        }

        public string CurrencyTo
        {
            get;
        }

        public string LastError { get; private set; }

        public ExchangeRateRetrieverStatus Status
        {
            get => _status;
            set
            {
                if (value != _status)
                {
                    _status = value;
                    StatusChanged?.Invoke(_status);
                }
            }
        }

        public ExchangeRateItem ExchangeRate
        {
            get => _exchangeRate;
            set
            {
                if (!Equals(value, _exchangeRate))
                {
                    _exchangeRate = value;
                    ExchangeRateChanged?.Invoke(_exchangeRate);
                }
            }
        }

        public void Start()
        {
            if (Status != ExchangeRateRetrieverStatus.Stopped)
            {
                throw new Exception($"Status of retriever [{Name}] is not STOPPED!");
            }

            _retrievingThread.Start();
            Status = ExchangeRateRetrieverStatus.Online;
        }

        public void Stop()
        {
            if (Status == ExchangeRateRetrieverStatus.Stopped)
            {
                return;
            }

            if (_retrievingThread?.IsAlive == true)
            {
                _retrievingThread.Abort();
            }

            Status = ExchangeRateRetrieverStatus.Stopped;
        }

        private void StartRetrieving()
        {
            while (true)
            {
                if (++_retryTimes > MaxRetryTimes)
                {
                    break;
                }

                try
                {
                    var resp = HttpReqHelper.Get($"https://hq.sinajs.cn/list=fx_s{CurrencyFrom.ToLower()}{CurrencyTo.ToLower()}");
                    if (string.IsNullOrWhiteSpace(resp))
                    {
                        throw new Exception("Response from remote end is null or white space!");
                    }

                    ExchangeRate = ParseSinaMessage(resp);

                    LastError = string.Empty;
                    Status = ExchangeRateRetrieverStatus.Online;
                    _retryTimes = 0;
                    Thread.Sleep(5000);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    LastError = ex.Message;
                    Status = ExchangeRateRetrieverStatus.Error;
                    Thread.Sleep(5000);
                }
            }

            Status = ExchangeRateRetrieverStatus.Stopped;
        }

        private ExchangeRateItem ParseSinaMessage(string message)
        {
            var arr = message.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 2)
            {
                throw new Exception("Unknown message format!");
            }

            var msg = arr[1];
            var arr2 = msg.Split(',');
            if (arr2.Length < 10)
            {
                throw new Exception("Unknown message format!");
            }

            return new ExchangeRateItem
            (
                DateTime.Parse(arr2[0]),
                CurrencyFrom,
                CurrencyTo,
                decimal.Parse(arr2[1]),
                decimal.Parse(arr2[3]),
                decimal.Parse(arr2[5]),
                decimal.Parse(arr2[6]),
                decimal.Parse(arr2[7]),
                arr2[9].Trim()
            );
        }
    }
}
