using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataContext;
using DataAccessService;
using Models;

namespace ChillApplication.Controllers
{
    public class IssuesController : Controller
    {
        private readonly DAS _context;

        public IssuesController(DAS context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetIssue());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var @issue = await _context.GetSpecificIssue(id);

            if (@issue == null)
            {
                return NotFound();
            }

            return View(@issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Picture,Resolved,IssueDate,ResolveDate")] Issue @issue)
        {
            if (ModelState.IsValid)
            {
                if (await _context.CreateIssue(@issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var @issue = await _context.GetSpecificIssue(id);

            if (@issue == null)
            {
                return NotFound();
            }

            return View(@issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Picture,Resolved,IssueDate,ResolveDate")] Issue @issue)
        {
            if (ModelState.IsValid)
            {
                if (await _context.EditIssue(@issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(@issue);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var @issue = await _context.GetSpecificIssue(id);

            if (@issue == null)
            {
                return NotFound();
            }

            return View(@issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @issue = await _context.GetSpecificIssue(id);

            if (@issue == null)
                return NotFound();

            var status = await _context.DeleteIssue(@issue);

            if (status == false)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
