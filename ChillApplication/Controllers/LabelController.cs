using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessService;
using Models;

namespace ChillApplication.Controllers
{
    public class LabelController : Controller
    {
        private readonly DAS _context;

        public LabelController(DAS context)
        {
            _context = context;
        }

        // GET: Label
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetLabel());
        }

        // GET: Label/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var label = await _context.GetSpecificLabel(id);

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
                if (await _context.CreateLabel(label) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: Label/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var label = await _context.GetSpecificLabel(id);

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
            if (ModelState.IsValid)
            {
                if (await _context.EditLabel(label) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: Label/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var label = await _context.GetSpecificLabel(id);

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
            var label = await _context.GetSpecificLabel(id);

            if (label == null)
                return NotFound();

            await _context.DeleteLabel(label);
            return RedirectToAction(nameof(Index));
        }
    }
}
