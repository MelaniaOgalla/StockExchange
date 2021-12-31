using BagLib.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BagLib.Services.Interfaces;
using ApiBase;

namespace BagLib.Services.Impl
{
    public class CurrencyImpl : ApiBaseClient, ICurrency
    {

        private static readonly CurrencyImpl _instance = new CurrencyImpl();

        public static CurrencyImpl Instance { get { return _instance; } }

        private CurrencyImpl() : base()
        {
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            var response = await Client.GetAsync("Currencies");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Currency>>();
            }
            return null;
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            var response = await Client.GetAsync($"Currencies?CurrencyId={id}");
            Currency currency = null;

            if (response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadAsAsync<List<Currency>>();
                if (result.Count > 0)
                {
                    currency = result[0];
                }
            }
            return currency;
        }
    }
}