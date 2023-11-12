using DataAccessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace ChillAPI.Controllers
{
    public class IssueController : Controller
    {

        private readonly DAS _context;

        public IssueController(DAS context)
        {
            _context = context;
        }
        // GET: IssueController
        public async Task<ActionResult> Index()
        {
            return View(await _context.GetIssue());
        }

        // GET: IssueController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var issue = await _context.GetSpecificIssue(id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: IssueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IssueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var issue = new Issue();
            issue.Id = Convert.ToInt16(collection["Id"]);
            issue.PicturePath = collection["PicturePath"];
            issue.State = false;

            if (ModelState.IsValid)
            {
                if (await _context.CreateIssue(issue) == null)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }
    }
}
