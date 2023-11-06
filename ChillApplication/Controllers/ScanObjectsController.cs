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
    public class ScanObjectsController : Controller
    {
        private readonly DAS _context;

        public ScanObjectsController(DAS context)
        {
            _context = context;
        }

        // GET: ScanObjects
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetScanObject());
        }

        // GET: ScanObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var @scanobject = await _context.GetSpecificScanObject(id);

            if (@scanobject == null)
            {
                return NotFound();
            }

            return View(@scanobject);
        }

        // GET: ScanObjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScanObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,X1,Y1,X2,Y2")] ScanObject @scanobject)
        {
            if (ModelState.IsValid)
            {
                if (await _context.CreateScanObject(@scanobject) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@scanobject);
        }

        // GET: ScanObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var @scanobject = await _context.GetSpecificScanObject(id);

            if (@scanobject == null)
            {
                return NotFound();
            }

            return View(@scanobject);
        }

        // POST: ScanObjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,X1,Y1,X2,Y2")] ScanObject @scanobject)
        {
            if (ModelState.IsValid)
            {
                if (await _context.EditScanObject(@scanobject) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@scanobject);
        }

        // GET: ScanObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var @scanobject = await _context.GetSpecificScanObject(id);

            if (@scanobject == null)
            {
                return NotFound();
            }

            return View(@scanobject);
        }

        // POST: ScanObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @scanobject = await _context.GetSpecificScanObject(id);

            if (@scanobject == null)
                return NotFound();

            var status = await _context.DeleteScanObject(@scanobject);

            if (status == false)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
