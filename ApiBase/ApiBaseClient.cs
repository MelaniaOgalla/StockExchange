using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace ApiBase
{
    public abstract class ApiBaseClient
    {
        protected readonly IConfiguration _configuration;

        protected string mUrl = "https://my-json-server.typicode.com/MelaniaOgalla/StockExhange/";
        protected HttpClient Client { get; set; }



        public ApiBaseClient()
        {
            //_configuration = configuration;
            Client = new HttpClient();
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