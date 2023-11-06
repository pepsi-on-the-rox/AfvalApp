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
    public class IssueController : Controller
    {
        private readonly DAS _context;

        public IssueController(DAS context)
        {
            _context = context;
        }

        // GET: Issue
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetIssue());
        }

        // GET: Issue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var issue = await _context.GetSpecificIssue(id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PicturePath,State,Createdate,Resolveddate,X1,X2,Y1,Y2")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                if (await _context.CreateIssue(issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // GET: Issue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var issue = await _context.GetSpecificIssue(id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PicturePath,State,Createdate,Resolveddate,X1,X2,Y1,Y2")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                if (await _context.EditIssue(issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // GET: Issue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var issue = await _context.GetSpecificIssue(id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.GetSpecificIssue(id);

            if (issue == null)
                return NotFound();

            await _context.DeleteIssue(@issue);
            return RedirectToAction(nameof(Index));
        }
    }
}
