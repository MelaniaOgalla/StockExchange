using BagLib.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BagLib.Services.Interfaces;
using ApiBase;
using Microsoft.Extensions.Configuration;

namespace BagLib.Services.Impl
{
    public class CountryImpl : ApiBaseClient, ICountry
    {

        private static readonly CountryImpl _instance = new CountryImpl();

        public static CountryImpl Instance { get { return _instance; } }

        private CountryImpl() : base()
        {
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var response = await Client.GetAsync("Countries");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Country>>();
            }
            return null;
        }
        public async Task<List<Country>> GetAllCountriesCurrenciesAsync()
        {
            var response = await Client.GetAsync("CountryCurrency");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Country>>();
            }
            return null;
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            var response = await Client.GetAsync($"Countries?CountryId={id}");
            Country country = null;

            if (response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadAsAsync<List<Country>>();
                if (result.Count > 0)
                {
                    country = result[0];
                }
            }
            return country;
        }
    }
}
