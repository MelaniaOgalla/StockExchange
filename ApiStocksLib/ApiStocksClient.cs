using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiStocksLib
{
    public class ApiStocksClient
    {
        public ApiStocksClient(string mUrl, string key)
        {
            this.mUrl = mUrl;
            Key = key;
        }

        public string mUrl { get; set; }

        protected string Key { get; set; }
        
        protected HttpClient client { get; set; }

        protected string GetRelative(string apiFunction , string querystring)
        {
            return $"query?function={apiFunction}&{querystring}&apikey={Key}";
        }

        public async Task<RootBestMatches> GetSearch(string text)
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(mUrl);

           var response = await client.GetAsync(GetRelative("SYMBOL_SEARCH", $"keywords={text}"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<RootBestMatches>();
            }

            return null;
        }

        public async Task<Company> GetCompany(string companyName)
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(mUrl);

            var response = await client.GetAsync(GetRelative("OVERVIEW", $"symbol={companyName}"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Company>();
            }

            return null;
        }

        public async Task<GlobalQuote> GetGlobalQuote(string companyName)
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(mUrl);

            var response = await client.GetAsync(GetRelative("GLOBAL_QUOTE", $"keywords={companyName}"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GlobalQuote>();
            }

            return null;
        }

    }
}
