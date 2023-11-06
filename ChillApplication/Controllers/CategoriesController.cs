using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataContext;
using Models;
using DataAccessService;

namespace ChillApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DAS _context;

        public CategoriesController(DAS context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetCategory());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var @category = await _context.GetSpecificCategory(id);

            if (@category == null)
            {
                return NotFound();
            }

            return View(@category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Category @category)
        {
            if (ModelState.IsValid)
            {
                if (await _context.CreateCategory(@category) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var @category = await _context.GetSpecificCategory(id);

            if (@category == null)
            {
                return NotFound();
            }

            return View(@category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Category @category)
        {
            if (ModelState.IsValid)
            {
                if (await _context.EditCategory(@category) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var @category = await _context.GetSpecificCategory(id);

            if (@category == null)
            {
                return NotFound();
            }

            return View(@category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @category = await _context.GetSpecificCategory(id);

            if (@category == null)
                return NotFound();
                
            var status = await _context.DeleteCategory(@category);

            if (status == false)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
