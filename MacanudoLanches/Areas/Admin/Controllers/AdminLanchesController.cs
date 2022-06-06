using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MacanudoLanches.Context;
using MacanudoLanches.Models;
using Microsoft.AspNetCore.Authorization;

namespace MacanudoLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLanchesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLanchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLanches
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Lanches.Include(l => l.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminLanches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lanches == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // GET: Admin/AdminLanches/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Description");
            return View();
        }

        // POST: Admin/AdminLanches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsLanchePreferred,InStock,CategoryId")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lanche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Description", lanche.CategoryId);
            return View(lanche);
        }

        // GET: Admin/AdminLanches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lanches == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Description", lanche.CategoryId);
            return View(lanche);
        }

        // POST: Admin/AdminLanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsLanchePreferred,InStock,CategoryId")] Lanche lanche)
        {
            if (id != lanche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancheExists(lanche.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Description", lanche.CategoryId);
            return View(lanche);
        }

        // GET: Admin/AdminLanches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lanches == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // POST: Admin/AdminLanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lanches == null)
            {
                return Problem("Entity set 'AppDbContext.Lanches'  is null.");
            }
            var lanche = await _context.Lanches.FindAsync(id);
            if (lanche != null)
            {
                _context.Lanches.Remove(lanche);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancheExists(int id)
        {
          return _context.Lanches.Any(e => e.Id == id);
        }
    }
}
