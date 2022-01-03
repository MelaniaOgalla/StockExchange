using BagLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagMVC.Services.Interfaces
{
    public interface ICountry
    {
        Task<List<Country>> GetAllCountriesAsync();

        Task<List<Country>> GetAllCountriesCurrenciesAsync();

        Task<Country> GetCountryByIdAsync(int id);
    }
}
