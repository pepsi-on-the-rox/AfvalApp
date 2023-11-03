using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChillApplication.Data;
using ChillApplication.Models;

namespace ChillApplication.Controllers
{
    public class OperatorsController : Controller
    {
        private readonly ChillApplicationContext _context;

        public OperatorsController(ChillApplicationContext context)
        {
            _context = context;
        }

        // GET: Operators
        public async Task<IActionResult> Index()
        {
              return _context.Operator != null ? 
                          View(await _context.Operator.ToListAsync()) :
                          Problem("Entity set 'ChillApplicationContext.Operator'  is null.");
        }

        // GET: Operators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Operator == null)
            {
                return NotFound();
            }

            var @operator = await _context.Operator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@operator == null)
            {
                return NotFound();
            }

            return View(@operator);
        }

        // GET: Operators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@operator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@operator);
        }

        // GET: Operators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Operator == null)
            {
                return NotFound();
            }

            var @operator = await _context.Operator.FindAsync(id);
            if (@operator == null)
            {
                return NotFound();
            }
            return View(@operator);
        }

        // POST: Operators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Operator @operator)
        {
            if (id != @operator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@operator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatorExists(@operator.Id))
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
            return View(@operator);
        }

        // GET: Operators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Operator == null)
            {
                return NotFound();
            }

            var @operator = await _context.Operator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@operator == null)
            {
                return NotFound();
            }

            return View(@operator);
        }

        // POST: Operators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operator == null)
            {
                return Problem("Entity set 'ChillApplicationContext.Operator'  is null.");
            }
            var @operator = await _context.Operator.FindAsync(id);
            if (@operator != null)
            {
                _context.Operator.Remove(@operator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperatorExists(int id)
        {
          return (_context.Operator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
