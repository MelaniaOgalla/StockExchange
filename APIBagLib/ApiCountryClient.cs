using APIBagLib;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace APICountryLib
{
    public class ApiCountryClient
    {
        public ApiCountryClient(string url, int version)
        {
            mUrl = url;
            Version = version;
        }

        protected string mUrl { get; set; }

        protected int Version { get; set; }

        protected HttpClient client { get; set; }

        protected string GetRelative(string name)
        {
            return $"/v{Version}/{name}";
        }

        public async Task<List<Country>> GetCountries()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(mUrl);

            //Para utilizar este codigo sin embeber el numero de la version:
            //var response = await client.GetAsync("/v2/all");

            var response = await client.GetAsync(GetRelative("all"));

            if (response.IsSuccessStatusCode)
            {
                //string chorizoJson = await response.Content.ReadAsStringAsync();
               return await response.Content.ReadAsAsync<List<Country>>();
            }
            else
            {

            }
            return null;
        }
    }
}
