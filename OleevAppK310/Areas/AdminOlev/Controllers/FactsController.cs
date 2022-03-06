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
    public class FactsController : Controller
    {
        private readonly OlDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FactsController(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: AdminOlev/Facts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fatcs.ToListAsync());
        }

        // GET: AdminOlev/Facts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _context.Fatcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // GET: AdminOlev/Facts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminOlev/Facts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,NumberCon")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fact);
        }

        // GET: AdminOlev/Facts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _context.Fatcs.FindAsync(id);
            if (fact == null)
            {
                return NotFound();
            }
            return View(fact);
        }

        // POST: AdminOlev/Facts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,NumberCon")] Fact fact)
        {
            if (id != fact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactExists(fact.Id))
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
            return View(fact);
        }

        // GET: AdminOlev/Facts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _context.Fatcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // POST: AdminOlev/Facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fact = await _context.Fatcs.FindAsync(id);
            _context.Fatcs.Remove(fact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactExists(int id)
        {
            return _context.Fatcs.Any(e => e.Id == id);
        }
    }
}
