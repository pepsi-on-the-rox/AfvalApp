using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataContext;
using Models;

namespace ChillApplication.Controllers
{
    public class LabelController : Controller
    {
        private readonly ChillApplicationContext _context;

        public LabelController(ChillApplicationContext context)
        {
            _context = context;
        }

        // GET: Label
        public async Task<IActionResult> Index()
        {
              return _context.Label != null ? 
                          View(await _context.Label.ToListAsync()) :
                          Problem("Entity set 'ChillApplicationContext.Label'  is null.");
        }

        // GET: Label/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Label == null)
            {
                return NotFound();
            }

            var label = await _context.Label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // GET: Label/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Label/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Label label)
        {
            if (ModelState.IsValid)
            {
                _context.Add(label);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: Label/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Label == null)
            {
                return NotFound();
            }

            var label = await _context.Label.FindAsync(id);
            if (label == null)
            {
                return NotFound();
            }
            return View(label);
        }

        // POST: Label/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Label label)
        {
            if (id != label.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(label);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelExists(label.Id))
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
            return View(label);
        }

        // GET: Label/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Label == null)
            {
                return NotFound();
            }

            var label = await _context.Label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // POST: Label/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Label == null)
            {
                return Problem("Entity set 'ChillApplicationContext.Label'  is null.");
            }
            var label = await _context.Label.FindAsync(id);
            if (label != null)
            {
                _context.Label.Remove(label);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelExists(int id)
        {
          return (_context.Label?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
