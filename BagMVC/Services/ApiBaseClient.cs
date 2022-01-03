using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace BagMVC.Services
{
    public abstract class ApiBaseClient
    {
        protected readonly IConfiguration _configuration;

        protected string mUrl = "https://my-json-server.typicode.com/MelaniaOgalla/StockExhange/";
        protected readonly HttpClient Client;

        public ApiBaseClient(HttpClient httpClient)
        {
            //_configuration = configuration;
            Client = httpClient;
            Client.BaseAddress = new Uri(mUrl);
        }

        //protected string GetRelative(string name)
        //{
        //    Client = new HttpClient();

        //    mUrl = _configuration["ConnectionStrings:JsonDB"].ToString();

        //    Client.BaseAddress = new Uri(mUrl);

        //    return $"{mUrl}/{name}";

        //}
    }
}