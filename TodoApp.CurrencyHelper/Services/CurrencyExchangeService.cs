using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApp.CurrencyHelper.Models;

namespace TodoApp.CurrencyHelper.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        public async Task<decimal> GetCurrentCurrencyValueForPLN(string currency)
        {
            string apiPath = "http://api.nbp.pl/api/exchangerates/rates/A/" + currency;
            var httpClient = new HttpClient();
            decimal currencyResult = 0.0m;

            HttpResponseMessage response = await httpClient.GetAsync(apiPath);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return currencyResult;
            }

            var stringResult = await httpClient.GetStringAsync(apiPath);
            var currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(stringResult);

            return currencyModel.Rates[0].Mid;

        }
    }
}
