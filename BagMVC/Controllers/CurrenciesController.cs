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
    public class CurrenciesController : _BaseController
    {
        private readonly ICurrency currencyImpl;

        public CurrenciesController(BagContext context, ICurrency currencyImpl) : base(context)
        {
            this.currencyImpl = currencyImpl;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Country.ToListAsync());
            return View(await currencyImpl.GetAllCurrenciesAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            Currency currency = await currencyImpl.GetCurrencyByIdAsync((int)id);

            if (currency == null) return NotFound();

            return View(currency);
        }
    }
}
