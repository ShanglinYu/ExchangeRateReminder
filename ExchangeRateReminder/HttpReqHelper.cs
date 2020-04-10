using System.Net.Http;

namespace ExchangeRateReminder
{
    static class HttpReqHelper
    {
        public static string Get(string url, int timeout = 10000)
        {
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.GetStringAsync(url);
                if (task.Wait(timeout))
                {
                    return task.Result;
                }
            }

            return string.Empty;
        }
    }
}
