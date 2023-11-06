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
    public class OperatorController : Controller
    {
        private readonly DAS _context;

        public OperatorController(DAS context)
        {
            _context = context;
        }

        // GET: Operator
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetOperators());
        }

        // GET: Operator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var @operator = await _context.GetSpecificOperator(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return View(@operator);
        }

        // GET: Operator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                if (await _context.CreateOperator(@operator) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@operator);
        }

        // GET: Operator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var @operator = await _context.GetSpecificOperator(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return View(@operator);
        }

        // POST: Operator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                if (await _context.EditOperator(@operator) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@operator);
        }

        // GET: Operator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var @operator = await _context.GetSpecificOperator(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return View(@operator);
        }

        // POST: Operator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @operator = await _context.GetSpecificOperator(id);

            if (@operator == null)
                return NotFound();

            var status = await _context.DeleteOperator(@operator);

            if (status == false)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
