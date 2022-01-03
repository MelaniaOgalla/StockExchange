using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BagLib;
using BagLib.Models;
using BagMVC.Services.Interfaces;
using BagMVC.Services.Impl;

namespace BagMVC.Controllers
{
    public class CountriesController : _BaseController
    {
        private readonly ICountry countryImpl;

        public CountriesController(BagContext context, ICountry countryImpl) : base(context)
        {
            this.countryImpl = countryImpl;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Country.ToListAsync());
            return View(await countryImpl.GetAllCountriesCurrenciesAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            Country country = await countryImpl.GetCountryByIdAsync((int)id);

            if (country == null) return NotFound();

            return View(country);
        }
    }

}