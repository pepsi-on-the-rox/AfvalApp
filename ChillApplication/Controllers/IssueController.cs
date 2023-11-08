using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessService;
using Models;
using Microsoft.Data.SqlClient;

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
        public async Task<IActionResult> Index(string sortOrder)
        {
            var issues = new List<Issue>();
            issues = await _context.GetIssue();

            switch (sortOrder)
            {
                case "date_asce":
                    issues = issues.OrderBy(s => s.Createdate).ToList();
                    break;
                case "date_desc":
                    issues = issues.OrderByDescending(s => s.Createdate).ToList();
                    break;
                case "completed":
                    issues = issues.Where(s => s.State == true).ToList();
                    break;

                case "not_completed":
                    issues = issues.Where(s => s.State == false).ToList();
                    break;


                default:
                    // Handle the default case when sortOrder is not recognized
                    break;
            }

            return View(issues);
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
        public async Task<IActionResult> Create()
        {
            var viewModel = new ModelViewIssue();
            viewModel.Operators = await _context.GetOperators();
            return View(viewModel);
        }

        // POST: Issue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelViewIssue viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Issue.Operator = await _context.GetSpecificOperator(viewModel.SelectedOperatorId);
                if (await _context.CreateIssue(viewModel.Issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Issue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var modelView = new ModelViewIssue();
            modelView.Issue = await _context.GetSpecificIssue(id);
            modelView.Operators = await _context.GetOperators();
            modelView.Labels = await _context.GetLabel();
            if (modelView.Issue == null)
            {
                return NotFound();
            }

            return View(modelView);
        }

        // POST: Issue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ModelViewIssue modelView)
        {
            if (ModelState.IsValid)
            {
                modelView.Issue.Operator = await _context.GetSpecificOperator(modelView.SelectedOperatorId);
                modelView.Issue.Label = await _context.GetSpecificLabel(modelView.SelectedLabelId);
                modelView.Issue.Resolveddate = DateTime.Now;
                if (await _context.EditIssue(modelView.Issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(modelView);
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
