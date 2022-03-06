#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OleevAppK310.Models;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area("AdminOlev")]
    public class SaleProductsController : Controller
    {
        private readonly OlDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SaleProductsController(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: AdminOlev/SaleProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.saleProducts.ToListAsync());
        }

        // GET: AdminOlev/SaleProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleProduct = await _context.saleProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleProduct == null)
            {
                return NotFound();
            }

            return View(saleProduct);
        }

        // GET: AdminOlev/SaleProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminOlev/SaleProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,SubHeader,Description,Discount,PhotoUrl")] SaleProduct saleProduct, IFormFile PhotoUrl)
        {
            if (ModelState.IsValid)
            {
                if(PhotoUrl != null)
                {
                    string filename = Guid.NewGuid() + PhotoUrl.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    PhotoUrl.CopyTo(fl);
                    saleProduct.PhotoUrl = "/images/" + filename;
                }
                _context.Add(saleProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleProduct);
        }

        // GET: AdminOlev/SaleProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleProduct = await _context.saleProducts.FindAsync(id);
            if (saleProduct == null)
            {
                return NotFound();
            }
            return View(saleProduct);
        }

        // POST: AdminOlev/SaleProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,SubHeader,Description,Discount,PhotoUrl")] SaleProduct saleProduct)
        {
            if (id != saleProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleProductExists(saleProduct.Id))
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
            return View(saleProduct);
        }

        // GET: AdminOlev/SaleProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleProduct = await _context.saleProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleProduct == null)
            {
                return NotFound();
            }

            return View(saleProduct);
        }

        // POST: AdminOlev/SaleProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleProduct = await _context.saleProducts.FindAsync(id);
            _context.saleProducts.Remove(saleProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleProductExists(int id)
        {
            return _context.saleProducts.Any(e => e.Id == id);
        }
    }
}
