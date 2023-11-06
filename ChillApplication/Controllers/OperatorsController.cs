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
    public class OperatorsController : Controller
    {
        private readonly DAS _context;

        public OperatorsController(DAS context)
        {
            _context = context;
        }

        // GET: Operators
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetOperators());
        }

        // GET: Operators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var @operator = await _context.GetSpecificOperator(id);

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
                if (await _context.CreateOperator(@operator) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@operator);
        }

        // GET: Operators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var @operator = await _context.GetSpecificOperator(id);

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

            if (ModelState.IsValid)
            {
                if (await _context.EditOperator(@operator) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@operator);
        }

        // GET: Operators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var @operator = await _context.GetSpecificOperator(id);

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
