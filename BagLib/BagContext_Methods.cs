using BagLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib
{
    public partial class BagContext : DbContext
    {
        public async Task <Currency> GetCurrencyAsync(string code)
        {
            return await Currencies.FirstOrDefaultAsync(d => d.Code == code);
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await Countries
                .Include(d => d.Currencies)
                .FirstOrDefaultAsync(d => d.Name == name || d.ApiName == name);
        }

        public async Task<Currency> InsertCurrencyAsync(Currency currency)
        {
            Add(currency);
            await SaveChangesAsync();
            return currency;
        }

        public async Task<Country> InsertCountryAsync(Country country)
        {
            Add(country);
            await SaveChangesAsync();
            return country;
        }

        public async Task<Country> GetCountryAsync(int? id)
        {
            return await Countries
                .Include(d => d.Currencies)
                .FirstOrDefaultAsync(m => m.CountryId == id);
        }

        public async Task<Stock> GetStockAsync(string symbol)
        {
            return await Stocks.FirstOrDefaultAsync(d => d.Ticket == symbol);
        }

        public async Task<Stock> InsertStockAsync(Stock stock)
        {
            Add(stock);
            await SaveChangesAsync();
            return stock;
        }

        public async Task<Market> GetMarketAsync(string name)
        {
            return await Markets.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<Market> InsertMarketAsync(Market market)
        {
            Add(market);
            await SaveChangesAsync();
            return market;
        }
    }
}
