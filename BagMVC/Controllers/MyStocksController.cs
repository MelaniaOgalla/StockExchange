using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BagLib;
using BagLib.Models;
using BagMVC.Models;
using Microsoft.Extensions.Configuration;

namespace BagMVC.Controllers
{
    public class MyStocksController : _BaseController
    {
        

        public MyStocksController(BagContext context, IConfiguration configuration) : base(context, configuration)
        {
           
        }

        // GET: MyStocks
        public async Task<IActionResult> Index()
        {
            var bagContext = _context.MyStocks.Include(m => m.BagUser).Include(m => m.Stock);
            return View(await bagContext.ToListAsync());
        }

        // GET: MyStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myStock = await _context.MyStocks
                .Include(m => m.BagUser)
                .Include(m => m.Stock)
                .FirstOrDefaultAsync(m => m.MyStockId == id);
            if (myStock == null)
            {
                return NotFound();
            }

            return View(myStock);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchMyStocksViewModel model)
        {
            ApiStocksLib.ApiStocksClient apiClient = GetStockApiClient();
            model.rootBestMatches = await apiClient.GetSearch(model.Text);
            return View(model);

        }


        // GET: MyStocks/Create
        public async Task<IActionResult> Create(string id)
        {
            //ApiStocksLib.ApiStocksClient apiClient = GetStockApiClient(); 
            //var company = await apiClient.GetCompany(id);

            Stock stock = await CheckAndCreate(id);

            MyStock myStock = new();

            myStock.Stock = stock;
            myStock.StockId = stock.StockId;
            myStock.BuyDate = DateTime.Now;

            return View(myStock);
        }

        // POST: MyStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyStockId,Amount,BuyPrice,BuyDate,StockId,BagUserId")] MyStock myStock)
        {
            if (ModelState.IsValid)
            {
                myStock.BagUserId = CurrentUserId;
                _context.Add(myStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BagUserId"] = new SelectList(_context.BagUsers, "BagUserId", "BagUserId", myStock.BagUserId);
            ViewData["StockId"] = new SelectList(_context.Stocks, "StockId", "StockId", myStock.StockId);
            return View(myStock);
        }

        // GET: MyStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myStock = await _context.MyStocks.FindAsync(id);
            if (myStock == null)
            {
                return NotFound();
            }
            ViewData["BagUserId"] = new SelectList(_context.BagUsers, "BagUserId", "BagUserId", myStock.BagUserId);
            ViewData["StockId"] = new SelectList(_context.Stocks, "StockId", "StockId", myStock.StockId);
            return View(myStock);
        }

        // POST: MyStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyStockId,Amount,BuyPrice,BuyDate,StockId,BagUserId")] MyStock myStock)
        {
            if (id != myStock.MyStockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyStockExists(myStock.MyStockId))
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
            ViewData["BagUserId"] = new SelectList(_context.BagUsers, "BagUserId", "BagUserId", myStock.BagUserId);
            ViewData["StockId"] = new SelectList(_context.Stocks, "StockId", "StockId", myStock.StockId);
            return View(myStock);
        }

        // GET: MyStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myStock = await _context.MyStocks
                .Include(m => m.BagUser)
                .Include(m => m.Stock)
                .FirstOrDefaultAsync(m => m.MyStockId == id);
            if (myStock == null)
            {
                return NotFound();
            }

            return View(myStock);
        }

        // POST: MyStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myStock = await _context.MyStocks.FindAsync(id);
            _context.MyStocks.Remove(myStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyStockExists(int id)
        {
            return _context.MyStocks.Any(e => e.MyStockId == id);
        }
    }
}
