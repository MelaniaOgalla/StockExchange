using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BagLib;
using BagLib.Models;

namespace BagMVC.Controllers
{
    public class CountriesController : _BaseController
    {
        //private readonly BagContext _context;

        public CountriesController(BagContext context): base(context)
        {
            
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries.Include(d => d.Currencies)
                .ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.GetCountryAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            //List<Currency> currencies = new List<Currency>();
            //currencies.Add(new Currency((int)CurrencyType.Dolar, CurrencyType.Dolar.ToString()));
            //currencies.Add(new Currency((int)CurrencyType.Pound, CurrencyType.Pound.ToString()));
            //currencies.Add(new Currency((int)CurrencyType.Euro, CurrencyType.Euro.ToString()));

            //ViewData["Currencies"] = new SelectList(currencies, "Id", "Name");


            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryId,Name,CurrencyType")] Country country)
        {
            if (id != country.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update()
        {
            APICountryLib.ApiCountryClient myApi = new APICountryLib.ApiCountryClient("https://restcountries.com", 2);

            var myResult = await myApi.GetCountries();

            foreach (var country in myResult)
            {
                var dbCountry = await _context.GetCountryByNameAsync(country.name);

                if (dbCountry == null)
                {
                    dbCountry = new Country(country.name);

                    dbCountry = await _context.InsertCountryAsync(dbCountry);
                }

                if (country.currencies != null)
                {
                    foreach (var currency in country.currencies)
                    {
                        var dbCurrency = await _context.GetCurrencyAsync(currency.code);

                        if (dbCurrency == null)
                        {
                            dbCurrency = new Currency(currency.code, currency.name, currency.symbol);

                            dbCurrency = await _context.InsertCurrencyAsync(dbCurrency);

                            // Si modifico las monedas relacionadas, guardo cambios
                            dbCountry.Currencies.Add(dbCurrency);

                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {

                }


            }


            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}
