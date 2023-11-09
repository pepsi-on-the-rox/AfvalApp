using DataAccessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ChillAPI.Controllers
{
    public class LabelController : Controller
    {
        private readonly DAS _context;

        public LabelController(DAS context)
        {
            _context = context;
        }
        // GET: LabelController
        public async Task<ActionResult> Index()
        {
            return View(await _context.GetIssue());
        }

        // GET: LabelController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var issue = await _context.GetSpecificIssue(id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: LabelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var label = new Label();
            label.Id = Convert.ToInt16(collection["Id"]);
            label.Name = Convert.ToString(collection["Name"]);
            label.Description = Convert.ToString(collection["Description"]);

            if (ModelState.IsValid)
            {
                if (await _context.CreateLabel(label) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: LabelController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var label = await _context.GetSpecificLabel(id);

            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // POST: LabelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var label = await _context.GetSpecificLabel(id);

            if (label == null)
                return NotFound();

            await _context.DeleteLabel(label);
            return RedirectToAction(nameof(Index));
        }
    }
}
